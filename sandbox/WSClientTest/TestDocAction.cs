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
    public class TestDocAction : AbstractTestWS {

        public override string GetWebServiceType() {
            return "DocActionInvoiceTest";
        }

        public override void TestPerformed() {
            SetDocActionRequest action = new SetDocActionRequest();
            action.DocAction = DocAction.Complete;
            action.Login = GetLogin();
            action.RecordID = 1000002;
            action.WebServiceType = GetWebServiceType();

            WebServiceConnection client = GetClient();

            try {
                StandardResponse response = client.SendRequest(action);

                if (response.Status == WebServiceResponseStatus.Error) {
                    Console.WriteLine(response.ErrorMessage);
                } else {
                    Console.WriteLine("RecordID: " + response.RecordID);
                    Console.WriteLine();
                }

            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
