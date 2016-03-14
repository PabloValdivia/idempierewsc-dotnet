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
    public class TestUpdateData : AbstractTestWS {

        public override string GetWebServiceType() {
            return "UpdateBPartnerTest";
        }

        public override void TestPerformed() {
            UpdateDataRequest createData = new UpdateDataRequest();
            createData.Login = GetLogin();
            createData.WebServiceType = GetWebServiceType();
            createData.RecordID = 1000004;

            DataRow data = new DataRow();
            data.AddField("Name", "Test BPartner Update C#");
            createData.DataRow = data;

            WebServiceConnection client = GetClient();

            try {
                StandardResponse response = client.SendRequest(createData);

                if (response.Status == WebServiceResponseStatus.Error) {
                    Console.WriteLine(response.ErrorMessage);
                } else {

                    Console.WriteLine("RecordID: " + response.RecordID);
                    Console.WriteLine();

                    for (int i = 0; i < response.OutputFields.GetFieldsCount(); i++) {
                        Console.WriteLine("Column" + (i + 1) + ": " + response.OutputFields.GetField(i).Column + " = " + response.OutputFields.GetField(i).Value);
                    }
                    Console.WriteLine();
                }

            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
