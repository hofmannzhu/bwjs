using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Admin
{
    public partial class FunctionAdd : AdminPage
    {
        public int FunctionID = 0;
        public string FunctionName = "";
        public string FunctionNameChild = "";
        public int FunctionType = 0;
        public int ParentID = 0;
        string RandomCode = "";
        public int LoginUserID = 0;
        public int FunctionId = 0;
        FunctionBLL Functionbll = new FunctionBLL();
        Function model = new Function();
        protected void Page_Load(object sender, EventArgs e)
        {

            LoginUserID = currentAdmin.UserID;
            if (Request.QueryString["FunctionId"] != null)
            {
                FunctionId = Convert.ToInt32(Request.QueryString["FunctionId"].ToString());
            }
            if (!IsPostBack)
            {
                this.btnSave.Text = "添加功能";
                FunctionBLL opFunctionBLL = new FunctionBLL();
                int maxOrderId = opFunctionBLL.GetMaxOrderId();
                txtOrderId.Value = maxOrderId.ToString();

                if (FunctionId > 0)
                {
                    DataSet ds = new DataSet();
                    ds = Functionbll.GetListParent("  f.FunctionId=" + FunctionId + " AND f.IsDeleted=0 ");
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["ParentFunctionName"].ToString() != "")
                            {
                                this.txtFunctionName.Value = ds.Tables[0].Rows[0]["ParentFunctionName"].ToString();
                                this.txtFunctionID.Value = ds.Tables[0].Rows[0]["ParentId"].ToString();
                            }
                            else {
                                this.txtFunctionName.Value = "添加根节点";
                                this.txtFunctionID.Value = "0";
                            }

                            this.HidFunctionCode.Value = ds.Tables[0].Rows[0]["FunctionCode"].ToString();
                            this.txtFunctionNameChild.Value = ds.Tables[0].Rows[0]["FunctionName"].ToString();
                            txtExternalLinkAddress.Value = ds.Tables[0].Rows[0]["ExternalLinkAddress"].ToString();
                            txtOrderId.Value = ds.Tables[0].Rows[0]["OrderId"].ToString();
                            this.SeleFunctionType.Value = ds.Tables[0].Rows[0]["ClassId"].ToString();
                            this.btnSave.Text = "修改功能";
                        }
                    }
                }

            }
            //DataSet ds = Functionbll.GetList(" IsDeleted=0");
            //DataTable dt = ds.Tables[0];
            //DataRow[] dr = ds.Tables[0].Select("ParentId=0");
            //TreeNode node = new TreeNode();
            //node.Text = dr[0]["FunctionName"].ToString();
            //node.Value = dr[0]["FunctionId"].ToString();
            //this.TreeView1.Nodes.Add(node);

            //BindTree(node, dr[0]["FunctionId"].ToString(), dt);
            //AddTree(0, null);
        }
        private void AddTree(int Pid, TreeNode PNode)
        {
            DataSet ds = Functionbll.GetList(" IsDeleted=0");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataView dv = new DataView(dt);
                //过滤ParentID,得到当前的所有子节点 ParentID为父节点ID
                dv.RowFilter = "[ParentId] = " + Pid;
                //循环递归
                foreach (DataRowView Row in dv)
                {
                    //声明节点
                    TreeNode Node = new TreeNode();
                    //绑定超级链接
                    Node.NavigateUrl = String.Format("javascript:show('{0}')", Row["FunctionName"].ToString());
                    //开始递归
                    if (PNode == null)
                    {
                        //添加根节点
                        Node.Text = Row["FunctionName"].ToString();
                        //TreeView1.Nodes.Add(Node);
                        Node.Expanded = true; //节点状态展开
                        AddTree(Int32.Parse(Row["FunctionId"].ToString()), Node);    //再次递归
                    }
                    else
                    {
                        //添加当前节点的子节点
                        Node.Text = Row["FunctionName"].ToString();
                        PNode.ChildNodes.Add(Node);
                        Node.Expanded = true; //节点状态展开
                        AddTree(Int32.Parse(Row["FunctionId"].ToString()), Node);     //再次递归
                    }
                }
            }
        }

        private void BindTree(TreeNode Nodes, string pid, DataTable dt)
        {
            DataRow[] dr = dt.Select("ParentId=" + pid);
            if (dr.Length > 0)
            {
                for (int i = 0; i < dr.Length; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dr[i]["FunctionName"].ToString();
                    node.Value = dr[i]["FunctionId"].ToString();
                    Nodes.ChildNodes.Add(node);

                    DataRow[] child = dt.Select(string.Format("ParentId={0}", dr[i]["FunctionId"]));
                    if (child.Length == 0)
                    {
                        BindTree(node, dr[i]["ParentId"].ToString(), dt);
                    }
                    //if (dr[i]["utype"].ToString() != "0") {
                    //    BindTree(node, dr[i]["ParentId"].ToString(), ds);
                    //}            
                }
            }
        }


        private void BindTree(string ParentId)
        {

            DataSet ds = Functionbll.GetList("Status > -1 and ParentId=" + ParentId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = ds.Tables[0].Rows[i]["FunctionName"].ToString();
                    node.Target = ds.Tables[0].Rows[i]["FunctionId"].ToString();
                    //this.TreeView1.Nodes.Add(node);
                    BindNode(node);
                }
            }
        }

        private void BindNode(TreeNode nd)
        {
            DataSet ds = Functionbll.GetList("Status>-1 and ParentId=" + Convert.ToString(nd.Target) + " order by FunctionId asc ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = ds.Tables[0].Rows[i]["FunctionName"].ToString();
                node.Target = ds.Tables[0].Rows[i]["FunctionId"].ToString();
                nd.ChildNodes.Add(node);

                //判断是否到最底层节点
                if (ds.Tables[0].Rows[i]["FunctionId"].ToString() != "0")
                {
                    BindNode(node);
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            FunctionInfoSave();
        }

        protected void btnRoot_Click(object sender, EventArgs e)
        {
            this.txtFunctionName.Value = "添加根节点";
            this.txtFunctionID.Value = "0";
        }


        /// <summary>
        /// 由字母和数字随机产生六位FunctionCode
        /// </summary>
        /// <returns></returns>
        public string GetRandomCode()
        {
            char[] chars = { 'a', '0', 'b', '1', 'c', '2', 'd', '3', 'e', '4', 'f', '5', 'g', '6', 'h', '7', 'i', '8', 'j', '9', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string code = string.Empty;
            for (int i = 0; i < 6; i++) //i<6 生成的就是六位的
            {
                Random rnd = new Random(GetRandomSeed());
                code += chars[rnd.Next(0, 36)].ToString();
            }
            return code;
        }

        public int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        protected void FunctionInfoSave()
        {
            FunctionBLL funInfoBLL = new FunctionBLL();
            FunctionNameChild = this.txtFunctionNameChild.Value.Trim();
            FunctionType = Convert.ToInt32(this.SeleFunctionType.Value.Trim());

            FunctionName = this.txtFunctionName.Value.ToString();
            try
            {
                ParentID = int.Parse(this.txtFunctionID.Value);
            }
            catch
            { }
            if (FunctionNameChild == "")
            {
                Response.Write(IFrameLayerClosetwo("请填写功能名称！"));
                Response.End();
            }
            if (FunctionNameChild.Length > 50)
            {
                Response.Write(IFrameLayerClosetwo("功能名称输入过长,请重新输入！"));
                Response.End();
            }

            if (this.SeleFunctionType.Value.Trim() == "2")
            {
                Response.Write(IFrameLayerClosetwo("请选择功能类型！"));
                Response.End();
            }
            if ((ParentID == FunctionId) && ParentID != 0 && FunctionId != 0)
            {
                Response.Write(IFrameLayerClosetwo("父级选择错误，请重新选择！"));
                Response.End();
            }
            DataSet ds = new DataSet();
            ds = funInfoBLL.GetList(" FunctionId<>" + FunctionId + " and  FunctionName='" + FunctionNameChild + "'  and IsDeleted=0 ");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write(IFrameLayerClosetwo("功能名称重复,重新填写！"));
                Response.End();
            }


            bool bFlag = false;
            if (this.btnSave.Text == "修改功能")
            {
                Function model = new Function();
                model.FunctionId = Request.QueryString["FunctionID"].ToString().ToInt();
                model.FunctionName = FunctionNameChild;
                model.ExternalLinkAddress = txtExternalLinkAddress.Value.Trim();
                model.OrderId = ComPage.SafeToInt(txtOrderId.Value.Trim());
                model.ParentId = ParentID;
                model.FunctionCode = this.HidFunctionCode.Value.ToString();
                model.ClassId = FunctionType;
                model.IsDeleted = 0;
                model.EditId = LoginUserID;
                model.EditDate = DateTime.Now;
                bFlag = funInfoBLL.Update(model);
                if (bFlag)
                {
                    Response.Write(IFrameLayerClosetwo("修改功能成功！"));
                    Response.End();
                }
                else
                {
                    Response.Write(IFrameLayerClosetwo("修改功能失败"));
                    Response.End();
                }
            }
            else
            {
                bool aFlag = false;
                RandomCode = GetRandomCode();
                aFlag = funInfoBLL.soleFunctionCode(RandomCode, 0);
                if (aFlag == true)
                {
                    RandomCode = GetRandomCode();
                }
                Function model = new Function();
                model.FunctionId = FunctionID;
                model.FunctionName = FunctionNameChild;
                model.ExternalLinkAddress = txtExternalLinkAddress.Value.Trim();
                model.OrderId = ComPage.SafeToInt(txtOrderId.Value.Trim());
                model.ParentId = ParentID;
                model.FunctionCode = RandomCode;
                model.ClassId = FunctionType;
                model.IsDeleted = 0;
                model.CreateId = LoginUserID;
                model.EditId = LoginUserID;
                model.EditDate = DateTime.Now;
                model.CreateDate = DateTime.Now;
                int FunctionIdNew = 0;
                FunctionIdNew = funInfoBLL.Add(model);
                if (FunctionIdNew > 0)
                {
                    Response.Write(IFrameLayerClosetwo("添加功能成功！"));
                    Response.End();
                }
                else
                {
                    Response.Write(IFrameLayerClosetwo("添加功能失败，继续添加！"));
                    Response.End();
                }
            }
        }

        public static string IFrameLayerClosetwo(string msg)
        {
            string s;
            s = "<script language=\"javascript\">\r\n";
            s += "parent.layer.msg('" + msg + "', 1, 1);\r\n";
            s += @"  setTimeout(function(){
                        parent.layer.close(parent.layer.getFrameIndex(window.name));
                      window.parent.GetFunctionTable();
                }, 2000 );";

            s += "</script>";
            return s;
        }
    }
}