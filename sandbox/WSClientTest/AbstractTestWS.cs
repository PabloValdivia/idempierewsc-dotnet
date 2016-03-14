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

namespace sandbox {
    public abstract class AbstractTestWS {

        private LoginRequest login;
        private WebServiceConnection client;

        public AbstractTestWS() {
            login = new LoginRequest();
            login.User = "SuperUser";
            login.Pass = "System";
            login.ClientID = 11;
            login.RoleID = 102;
            login.OrgID = 0;

            client = new WebServiceConnection();
            client.Attempts = 3;
            client.Timeout = 2000;
            client.AttemptsTimeout = 2000;
            client.Url = GetUrlBase();
            client.AppName = "C# Test WS Client";
            RunTest();
        }

        public LoginRequest GetLogin() {
            return login;
        }

        public string GetUrlBase() {
            return "http://localhost:8080";
        }

        public WebServiceConnection GetClient() {
            return client;
        }

        public void PrintTotal() {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Web Service: " + GetWebServiceType());
            Console.WriteLine("Attempts: " + client.AttemptsRequest);
            Console.WriteLine("Time: " + client.TimeRequest);
            Console.WriteLine("--------------------------");
        }

        public void SaveRequestResponse() {
            GetClient().WriteRequest("../documents/" + GetWebServiceType() + "_request.xml");
            GetClient().WriteResponse("../documents/" + GetWebServiceType() + "_response.xml");
        }

        public void PrintRequestResponse() {
            GetClient().WriteRequest(Console.Out);
            Console.WriteLine();
            Console.WriteLine();
            GetClient().WriteResponse(Console.Out);
        }

        public void RunTest() {
            TestPerformed();
            SaveRequestResponse();
            PrintTotal();
            Console.ReadLine();
        }

        public abstract string GetWebServiceType();

        public abstract void TestPerformed();
    }
}
