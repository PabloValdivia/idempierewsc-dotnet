idempierewsc-dotnet
===================

Description
-----------
iDempiere C# WebService Client is a Soap Client for
iDempiere ERP (http://www.idempiere.org).
It allows the programmer to abstract the generation of XML requests,
making development easier. This implementation can be used in .NET 4.5 and .NET 3.5 CF.

Data GardenWorld: documents/Test WebServices 2Pack.zip.
Examples are available in the sandbox folder.


Features
--------
- Copyright: 2016 Saúl Piña <sauljabin@gmail.com>
- Repository: https://github.com/sauljabin/idempierewsc-dotnet
- License: LGPL 3
- Language: C#, .NET 4.5
- IDE: Visual Studio 2012, MonoDevelop 5.9.6
- Version: v1.6.0


Links
-----
- iDempiere Webservices: http://wiki.idempiere.org/en/Web_services


Example Create BPartner and Image
---------------------------------
- Source:

```cs
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
```

- Output:

```xml
<?xml version="1.0" encoding="utf-8"?>
<soapenv:Envelope xmlns:_0="http://idempiere.org/ADInterface/1_0" xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/">
  <soapenv:Header />
  <soapenv:Body>
    <_0:compositeOperation>
      <_0:CompositeRequest>
        <_0:serviceType>CompositeBPartnerTest</_0:serviceType>
        <_0:operations>
          <_0:operation preCommit="false" postCommit="false">
            <_0:TargetPort>createData</_0:TargetPort>
            <_0:ModelCRUD>
              <_0:serviceType>CreateImageTest</_0:serviceType>
              <_0:DataRow>
                <_0:field column="Name">
                  <_0:val>img/idempiere-logo.png</_0:val>
                </_0:field>
                <_0:field column="Description">
                  <_0:val>Test Create BPartner and Logo</_0:val>
                </_0:field>
                <_0:field column="BinaryData">
                  <_0:val>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</_0:val>
                </_0:field>
              </_0:DataRow>
            </_0:ModelCRUD>
          </_0:operation>
          <_0:operation preCommit="false" postCommit="false">
            <_0:TargetPort>createData</_0:TargetPort>
            <_0:ModelCRUD>
              <_0:serviceType>CreateBPartnerTest</_0:serviceType>
              <_0:DataRow>
                <_0:field column="Name">
                  <_0:val>Test BPartner</_0:val>
                </_0:field>
                <_0:field column="Value">
                  <_0:val>Test_BPartner From C#4660000</_0:val>
                </_0:field>
                <_0:field column="TaxID">
                  <_0:val>123456</_0:val>
                </_0:field>
                <_0:field column="Logo_ID">
                  <_0:val>@AD_Image.AD_Image_ID</_0:val>
                </_0:field>
              </_0:DataRow>
            </_0:ModelCRUD>
          </_0:operation>
        </_0:operations>
        <_0:ADLoginRequest>
          <_0:user>SuperUser</_0:user>
          <_0:pass>System</_0:pass>
          <_0:ClientID>11</_0:ClientID>
          <_0:RoleID>102</_0:RoleID>
          <_0:OrgID>0</_0:OrgID>
        </_0:ADLoginRequest>
      </_0:CompositeRequest>
    </_0:compositeOperation>
  </soapenv:Body>
</soapenv:Envelope>

<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <ns1:compositeOperationResponse xmlns:ns1="http://idempiere.org/ADInterface/1_0">
      <CompositeResponses xmlns="http://idempiere.org/ADInterface/1_0">
        <CompositeResponse>
          <StandardResponse RecordID="1000040">
            <outputFields>
              <outputField column="AD_Image_ID" value="1000040">
              </outputField>
              <outputField column="BinaryData" value="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">
              </outputField>
              <outputField column="Description" value="Test Create BPartner and Logo">
              </outputField>
              <outputField column="Name" value="img/idempiere-logo.png">
              </outputField>
            </outputFields>
          </StandardResponse>
          <StandardResponse RecordID="1000125">
            <outputFields>
              <outputField column="C_BPartner_ID" value="1000125">
              </outputField>
              <outputField column="Name" value="Test BPartner">
              </outputField>
              <outputField column="TaxID" value="123456">
              </outputField>
              <outputField column="Value" value="Test_BPartner From C#4660000">
              </outputField>
            </outputFields>
          </StandardResponse>
        </CompositeResponse>
      </CompositeResponses>
    </ns1:compositeOperationResponse>
  </soap:Body>
</soap:Envelope>

StandardResponse
CreateImageTest

StandardResponse
CreateBPartnerTest

--------------------------
Web Service: CompositeBPartnerTest
Attempts: 1
Time: 729
--------------------------
```

- iDempiere Output:

![](/documents/printscreen-1.png)

![](/documents/printscreen-2.png)

- WinCE PrintScreen Example:

![](/documents/printscreen-3.png)
