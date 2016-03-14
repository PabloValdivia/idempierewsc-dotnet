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
using System.IO;

namespace sandbox {
    
    public class TestCreateImage : AbstractTestWS {

        public override string GetWebServiceType() {
            return "CompositeBPartnerTest";
        }

        public override void TestPerformed() {
            CompositeOperationRequest compositeOperation = new CompositeOperationRequest();
            compositeOperation.Login = GetLogin();
            compositeOperation.WebServiceType = GetWebServiceType();

            CreateDataRequest createImage = new CreateDataRequest();
            createImage.WebServiceType = "CreateImageTest";

            String imageName = "img/idempiere-logo.png";

            DataRow data = new DataRow();
            data.AddField("Name", imageName);
            data.AddField("Description", "Test Create BPartner and Logo");

            byte[] fileBytes = File.ReadAllBytes(imageName);
            data.AddField("BinaryData", fileBytes);           

            createImage.DataRow = data;

            CreateDataRequest createBP = new CreateDataRequest();
            createBP.WebServiceType = "CreateBPartnerTest";

            DataRow dataBP = new DataRow();
            dataBP.AddField("Name", "Test BPartner");
            dataBP.AddField("Value", "Test_BPartner From C#" + Environment.TickCount);
            dataBP.AddField("TaxID", "123456");
            dataBP.AddField("Logo_ID", "@AD_Image.AD_Image_ID");
            createBP.DataRow = dataBP;

            compositeOperation.AddOperation(createImage);
            compositeOperation.AddOperation(createBP);

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
                            Console.WriteLine(response.GetResponse(i).WebServiceType);
                        }
                        Console.WriteLine();
                    }
                }

            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}

