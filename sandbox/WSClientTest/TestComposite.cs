////
/// Copyright (c) 2016 Saúl Piña <sauljabin@gmail.com>.
/// 
/// This file is part of idempierewsc.
/// 
/// idempierewsc is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Lesser General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
/// (at your option) any later version.
/// 
/// idempierewsc is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU Lesser General Public License for more details.
/// 
/// You should have received a copy of the GNU Lesser General Public License
/// along with idempierewsc.  If not, see <http://www.gnu.org/licenses/>.
////

using System;
using WebService.Base;
using WebService.Request;
using WebService.Response;
using WebService.Net;
using WebService.Base.Enums;

namespace sandbox {

    public class TestComposite : AbstractTestWS {

        public override string GetWebServiceType() {
            return "CompositeMovementTest";
        }

        public override void TestPerformed() {
            CompositeOperationRequest compositeOperation = new CompositeOperationRequest();
            compositeOperation.Login = GetLogin();
            compositeOperation.WebServiceType = GetWebServiceType();

            CreateDataRequest createMovement = new CreateDataRequest();
            createMovement.WebServiceType = "CreateMovementTest";
            DataRow data = new DataRow();
            data.AddField("C_DocType_ID", "143");
            data.AddField("MovementDate", "2015-10-25 00:00:00");
            data.AddField("AD_Org_ID", "11");
            createMovement.DataRow = data;

            CreateDataRequest createMovementLine = new CreateDataRequest();
            createMovementLine.WebServiceType = "CreateMovementLineTest";
            DataRow dataLine = new DataRow();
            dataLine.AddField("M_Movement_ID", "@M_Movement.M_Movement_ID");
            dataLine.AddField("M_Product_ID", "138");
            dataLine.AddField("MovementQty", "1");
            dataLine.AddField("M_Locator_ID", "50001");
            dataLine.AddField("M_LocatorTo_ID", "50000");
            dataLine.AddField("AD_Org_ID", "11");
            createMovementLine.DataRow = dataLine;

            SetDocActionRequest docAction = new SetDocActionRequest();
            docAction.DocAction = DocAction.Complete;
            docAction.WebServiceType = "DocActionMovementTest";
            docAction.RecordIDVariable = "@M_Movement.M_Movement_ID";

            compositeOperation.AddOperation(createMovement);
            compositeOperation.AddOperation(createMovementLine);
            compositeOperation.AddOperation(docAction);

            WebServiceConnection client = GetClient();

            try {
                CompositeResponse response = client.SendRequest(compositeOperation);

                if (response.Status == WebServiceResponseStatus.Error) {
                    Console.WriteLine(response.ErrorMessage);
                } else {
                    for (int i = 0; i < response.GetResponsesCount(); i++) {
                        if (response.GetResponse(i).Status == WebServiceResponseStatus.Error) {
                            Console.WriteLine(response.GetResponse(i).ErrorMessage);
                        } else {
                            Console.WriteLine(response.GetResponse(i).GetWebServiceResponseModel());
                        }
                    }
                }

            } catch (Exception e) {
                Console.WriteLine(e);
            }

        }
    }
}
