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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Base;
using WebService.Request;
using WebService.Response;
using WebService.Net;
using WebService.Base.Enums;
using System.IO;

namespace sandbox {

    public class ExampleCreateImage {

        public static LoginRequest GetLogin() {
            LoginRequest login = new LoginRequest();
            login.User = "SuperUser";
            login.Pass = "System";
            login.ClientID = 11;
            login.RoleID = 102;
            login.OrgID = 0;
            return login;
        }

        public static string GetUrlBase() {
            return "http://192.168.100.5:8031";
        }

        public static WebServiceConnection GetClient() {
            WebServiceConnection client = new WebServiceConnection();
            client.Attempts = 3;
            client.Timeout = 2000;
            client.AttemptsTimeout = 2000;
            client.Url = GetUrlBase();
            client.AppName = "C# Test WS Client";
            return client;
        }

        static void Main(string[] args) {
            // CREATE COMPOSITE WS
            CompositeOperationRequest compositeOperation = new CompositeOperationRequest();
            compositeOperation.Login = GetLogin();
            compositeOperation.WebServiceType = "CompositeBPartnerTest";

            // CREATE IMAGE WS
            CreateDataRequest createImage = new CreateDataRequest();
            createImage.WebServiceType = "CreateImageTest";

            String imageName = "img/idempiere-logo.png";

            DataRow data = new DataRow();
            data.AddField("Name", imageName);
            data.AddField("Description", "Test Create BPartner and Logo");

            byte[] fileBytes = File.ReadAllBytes(imageName);
            data.AddField("BinaryData", fileBytes);

            createImage.DataRow = data;

            // CREATE BP WS
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
                // GET RESPONSE
                CompositeResponse response = client.SendRequest(compositeOperation);

                client.WriteRequest(Console.Out);
                Console.WriteLine();
                Console.WriteLine();
                client.WriteResponse(Console.Out);
                Console.WriteLine();
                Console.WriteLine();

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

                Console.WriteLine("--------------------------");
                Console.WriteLine("Web Service: CompositeBPartnerTest");
                Console.WriteLine("Attempts: " + client.AttemptsRequest);
                Console.WriteLine("Time: " + client.TimeRequest);
                Console.WriteLine("--------------------------");
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
