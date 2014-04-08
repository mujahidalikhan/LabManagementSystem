using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMIS.DBModel;
using LMIS.DBController;
namespace LMIS.Admin
{
    public partial class UpdateRewardValue : System.Web.UI.Page
    {
        public static RewardValue objRewardValue;
        static readonly DbController objDbController = new DbController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objRewardValue = objDbController.GetRewardValue();
                rewardValue.Text = objRewardValue.ExchageRate.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(rewardValue.Text) <= 0)
            {
                errorMessage.Visible = true;
                return;
            }
            errorMessage.Visible = false;
            objRewardValue.ExchageRate = decimal.Parse(rewardValue.Text);

            objDbController.UpdateRewardValue(objRewardValue);
        }
    }
}