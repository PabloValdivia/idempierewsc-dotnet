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
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebService.Base;
using WebService.Request;
using WebService.Response;
using WebService.Base.Enums;
using WebService.Net;
using System.IO;

namespace sandbox_wince {
    public partial class TestConnection : Form {

        public TestConnection() {
            InitializeComponent();
        }

        public LoginRequest GetLogin() {
            LoginRequest login = new LoginRequest();
            login.User = "SuperUser";
            login.Pass = "System";
            login.ClientID = 11;
            login.RoleID = 102;
            login.OrgID = 0;
            return login;
        }

        public string GetUrlBase() {
            return txtUrl.Text;
        }

        public void RunQueryWS() {
            QueryDataRequest ws = new QueryDataRequest();
            ws.WebServiceType = "QueryBPartnerTest";
            ws.Login = GetLogin();

            DataRow data = new DataRow();
            data.AddField("Name", "%" + txtQueryName.Text + "%");
            ws.DataRow = data;

            WebServiceConnection client = new WebServiceConnection();
            client.Attempts = 1;
            client.AttemptsTimeout = 1000;
            client.Timeout = 5000;
            client.Url = GetUrlBase();

            try {
                WindowTabDataResponse response = client.SendRequest(ws);

                if (response.Status == WebServiceResponseStatus.Error) {
                    txtQueryResult.Text = response.ErrorMessage;
                } else {

                    string temp = "";

                    for (int i = 0; i < response.DataSet.GetRowsCount(); i++) {
                        for (int j = 0; j < response.DataSet.GetRow(i).GetFieldsCount(); j++) {
                            Field field = response.DataSet.GetRow(i).GetFields()[j];
                            temp += field.Column + " = " + field.Value + "\r\n";

                            if (field.Column.Equals("Logo_ID") && field.Value.ToString() != "") {

                                ReadDataRequest readImage = new ReadDataRequest();
                                readImage.WebServiceType = "ReadImageTest";
                                readImage.Login = GetLogin();
                                readImage.RecordID = field.GetIntValue();

                                try {
                                    WindowTabDataResponse responseRead = client.SendRequest(readImage);

                                    if (responseRead.Status == WebServiceResponseStatus.Error) {
                                        txtQueryResult.Text = responseRead.ErrorMessage;
                                    } else if (responseRead.Status == WebServiceResponseStatus.Unsuccessful) {
                                        txtQueryResult.Text = "Unsuccessful";
                                    } else {
                                        if (responseRead.DataSet.GetRow(0).GetField("BinaryData") != null && responseRead.DataSet.GetRow(0).GetField("BinaryData").ToString() != "") {
                                            byte[] byteImgQuery = responseRead.DataSet.GetRow(0).GetField("BinaryData").GetByteValue();
                                            imgLogo.Image = ToImage(byteImgQuery);
                                        }
                                    }

                                } catch (Exception e) {
                                    txtQueryResult.Text = e.Message;
                                }

                            }
                        }
                    }
                    txtQueryResult.Text = temp;
                }

            } catch (Exception e) {
                txtQueryResult.Text = "Error: " + e.Message;
            }
        }

        private byte[] ReadAllBytes(string fileName) {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

        public Bitmap ToImage(byte[] array) {
            Bitmap image = new Bitmap(new MemoryStream(array));
            return image;
        }

        public void RunCreateWS() {
            CompositeOperationRequest compositeOperation = new CompositeOperationRequest();
            compositeOperation.Login = GetLogin();
            compositeOperation.WebServiceType = "CompositeBPartnerTest";

            CreateDataRequest createImage = new CreateDataRequest();
            createImage.WebServiceType = "CreateImageTest";

            String imageName = txtCreateLogo.Text;

            DataRow data = new DataRow();
            data.AddField("Name", imageName);
            data.AddField("Description", "Test Create BPartner and Logo");

            byte[] fileBytes = ReadAllBytes(imageName);
            data.AddField("BinaryData", fileBytes);

            createImage.DataRow = data;

            CreateDataRequest createBP = new CreateDataRequest();
            createBP.WebServiceType = "CreateBPartnerTest";

            DataRow dataBP = new DataRow();
            dataBP.AddField("Name", txtCreateName.Text);
            dataBP.AddField("Value", txtCreateValue.Text);
            dataBP.AddField("TaxID", txtCreateTaxID.Text);
            dataBP.AddField("Logo_ID", "@AD_Image.AD_Image_ID");
            createBP.DataRow = dataBP;

            compositeOperation.AddOperation(createImage);
            compositeOperation.AddOperation(createBP);

            WebServiceConnection client = new WebServiceConnection();
            client.Attempts = 1;
            client.AttemptsTimeout = 1000;
            client.Timeout = 5000;
            client.Url = GetUrlBase();

            try {
                CompositeResponse response = client.SendRequest(compositeOperation);

                if (response.Status == WebServiceResponseStatus.Error) {
                    Console.WriteLine(response.ErrorMessage);
                } else {
                    MessageBox.Show("Created");
                }

            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            RunQueryWS();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            RunCreateWS();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            FileChooser fc = new FileChooser();
            if (fc.ShowDialog() == DialogResult.OK) {
                txtCreateLogo.Text = fc.CurrentFile;
            }
        }


    }
}