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
    public class TestQueryImage : AbstractTestWS {
        
        public override string GetWebServiceType() {
            return "QueryImageTest";
        }

        public override void TestPerformed() {
            QueryDataRequest ws = new QueryDataRequest();
            ws.WebServiceType = GetWebServiceType();
            ws.Login = GetLogin();
            ws.Limit = 1;        
            ws.Offset = 8;

            WebServiceConnection client = GetClient();

            try {
                WindowTabDataResponse response = client.SendRequest(ws);

                if (response.Status == WebServiceResponseStatus.Error) {
                    Console.WriteLine(response.ErrorMessage);
                } else if (response.Status == WebServiceResponseStatus.Unsuccessful) {
                    Console.WriteLine("Unsuccessful");
                } else {
                    Console.WriteLine("Total rows: " + response.NumRows);
                    Console.WriteLine();
                    for (int i = 0; i < response.DataSet.GetRowsCount(); i++) {
                        Console.WriteLine("Row: " + (i + 1));
                        for (int j = 0; j < response.DataSet.GetRow(i).GetFieldsCount(); j++) {
                            Field field = response.DataSet.GetRow(i).GetFields()[j];
                            Console.WriteLine("Column: " + field.Column + " = " + field.Value);

                            if (field.Column.Equals("BinaryData") && !string.IsNullOrEmpty(field.Value.ToString())) {
                                File.WriteAllBytes("img/QueryImageTest_" + response.DataSet.GetRow(i).GetField("AD_Image_ID").Value.ToString() + ".png", field.GetByteValue());
                            }

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

