using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices.ComTypes;
using System.EnterpriseServices;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace AnimalsClassification
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        string getApiKey(string classificationOption)
        {
            if (classificationOption == "0")
            {
                return "Bearer nxHWB6gGT4jtVJi4DtpadTlaOFrpkvNqxzpe9RwUoBHQaB8dSKh4Pwacc66zP6I42Z3AS9KHUc1r+AMCmZ6pyg==";
            }
            else if (classificationOption == "1")
            {
                return "Bearer BQktaYwBCsu3OJjPw+Fw7/omDk0c2fxgvn/ngIBggVy0Nl74nbJi7+ydsUWQ3By8aCBxUdBFhnxt+AMCzGS0hg==";
            }

            else if (classificationOption == "2")
            {
                return "Bearer HmlaU6u6cQwTvVd4WLbQwIIq9CwTLhBY+GjCshx87gopYfCKK8o3uPRljKNeIYey8VcQV8oltWqP+AMCSli8Qw==";
            }
            return "Bearer 8MI1kvaR4yDmY0+VRjv+gzc5WSPcws1rpw+M+k53q6HaXzfJqVl0cL/FJM0gR32jOe/YMLxOtHSu+AMCXTNVNg==";



        }

        string getAPILink(string classificatioOption)
        {
            if (classificatioOption == "0")
            {
                return "https://ussouthcentral.services.azureml.net/workspaces/c69f1a1ede6a47118efc554ecb5ca815/services/c58233bdcd854f2b8bb6a4b8bedee4d7/execute?api-version=2.0&details=true";
            }

            if (classificatioOption == "1")
            {
                return "https://ussouthcentral.services.azureml.net/workspaces/c69f1a1ede6a47118efc554ecb5ca815/services/20ccab59d7da46928cfc7570c7fdc412/execute?api-version=2.0&details=true";
            }

            if (classificatioOption == "2")
            {
                return "https://ussouthcentral.services.azureml.net/workspaces/c69f1a1ede6a47118efc554ecb5ca815/services/c93c0e7cf7144cc7b23f48bebd57f483/execute?api-version=2.0&details=true";
            }
            return "https://ussouthcentral.services.azureml.net/workspaces/c69f1a1ede6a47118efc554ecb5ca815/services/9712d0638f844a80ad5555a98c75a659/execute?api-version=2.0&details=true";
        }
        public async Task sendRequestAsync()
        {
            string[] data = new string[2];

            data[0] = getApiKey(ClassificationOptions.SelectedValue);

            data[1] = getAPILink(ClassificationOptions.SelectedValue);

            string animalName = AnimalNameTextBox.Text;

            string[] values = new string[16];
            values[0] = DropDownList2.SelectedValue;
            values[1] = FeathersDownList.SelectedValue;
            values[2] = EggsDropDownList.SelectedValue;
            values[3] = MilkDropDownList.SelectedValue;
            values[4] = AirborneDropDownList.SelectedValue;
            values[5] = AquaticDropDownList.SelectedValue;
            values[6] = PredatorDropDownList.SelectedValue;
            values[7] = ToothedDropDownList.SelectedValue;
            values[8] = BackboneDropDownList.SelectedValue;
            values[9] = BreathesDropDownList.SelectedValue;
            values[10] = VenomousDropDownList.SelectedValue;
            values[11] = FinsDropDownList.SelectedValue;
            values[12] = LegsTextbox.Text;
            values[13] = TailDropDownList.SelectedValue;
            values[14] = DomesticDropDownList.SelectedValue;
            values[15] = CatsizeDropDownList.SelectedValue;

            if (values[12] == "")
            {
                ResultValue.Text = "Error, number of legs is empty.";
                ResultValue.ForeColor = System.Drawing.Color.Red;
            }
            else if (Convert.ToInt32(values[12]) < 0)
            {
                ResultValue.Text = "Error, number of legs cannot be less than 0.";
                ResultValue.ForeColor = System.Drawing.Color.Red;
            }
            else if (Convert.ToInt32(values[12]) > 8)
            {
                ResultValue.Text = "Error, number of legs cannot be greater than 8.";
                ResultValue.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                var options = new RestClientOptions()
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest(data[1], Method.Post);
                request.AddHeader("Authorization", data[0]);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");

                var body = "{\"Inputs\":{\"input1\":{\"ColumnNames\":[\"animal_name\",\"hair\",\"feathers\",\"eggs\",\"milk\",\"airborne\",\"aquatic\",\"predator\",\"toothed\",\"backbone\",\"breathes\",\"venomous\",\"fins\",\"legs\",\"tail\",\"domestic\",\"catsize\",\"class_type\"],\"Values\":[[\"" + animalName + "\",\"" + values[0] + "\",\"" + values[1] + "\",\"" + values[2] + "\",\"" + values[3] + "\",\"" + values[4] + "\",\"" + values[5] + "\",\"" + values[6] + "\",\"" + values[7] + "\",\"" + values[8] + "\",\"" + values[9] + "\",\"" + values[10] + "\",\"" + values[11] + "\",\"" + values[12] + "\", \"" + values[13] + "\", \"" + values[14] + "\", \"" + values[15] + "\", \"0\"]]}},\"GlobalParameters\":{}}";

                request.AddStringBody(body, DataFormat.Json);

                var response = client.Execute(request);


                var results = JObject.Parse(response.Content);
                var resultValues = results["Results"]["output1"]["value"]["Values"].Last().Last().ToString();

                string[] strings = results["Results"]["output1"]["value"]["Values"].Last().ToString().Split(',');


                double[] percentages = new double[7];
                int i;
                for (i = 17; i < 24; i++)
                {
                    strings[i] = strings[i].Replace("\"", string.Empty);
                    strings[i] = strings[i].Replace(" ", string.Empty);

                }


                percentages[0] = Convert.ToDouble(strings[17]) * 100;
                percentages[1] = Convert.ToDouble(strings[18]) * 100;
                percentages[2] = Convert.ToDouble(strings[19]) * 100;
                percentages[3] = Convert.ToDouble(strings[20]) * 100;
                percentages[4] = Convert.ToDouble(strings[21]) * 100;
                percentages[5] = Convert.ToDouble(strings[22]) * 100;
                percentages[6] = Convert.ToDouble(strings[23]) * 100;

                percentages[0] = Math.Round(percentages[0], 2);
                percentages[1] = Math.Round(percentages[1], 2);
                percentages[2] = Math.Round(percentages[2], 2);
                percentages[3] = Math.Round(percentages[3], 2);
                percentages[4] = Math.Round(percentages[4], 2);
                percentages[5] = Math.Round(percentages[5], 2);
                percentages[6] = Math.Round(percentages[6], 2);

                double max = percentages.Max();

                ResultValue.Text = "The predicted animal classification is " + animalClassification(resultValues) + " with the probability of " + max + "%.";
            }
        }
        string animalClassification(string value)
        {
            if(value == "1")
            {
                return "Mammal";
            }
            if(value == "2")
            {
                return "Bird";
            }
            if (value == "3") {
                return "Reptile"; 
            }

            if (value == "4")
            {
                return "Fish";
            }

            if (value == "5")
            {
                return "Amphibian";
            }

            if (value == "6")
            {
                return "Insect";
            }
            return "Other";
        }

        
        protected void PredictButton_Click(object sender, EventArgs e)
        {
            _ = sendRequestAsync();
        }
    }
}


    
   
    
            


