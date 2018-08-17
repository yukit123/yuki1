<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modal popup2.aspx.cs" Inherits="WebApplication2.modal_popup2" %>

<head>
    <title>Bootstrap </title>
    <link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <script src="scripts/jquery-3.3.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
        //$("#LinkButton1").click(function () {

        //   $('#myModal').modal('show');

        //});
    </script>
</head>
<form id="form1" runat="server">
    <asp:linkbutton id="LinkButton1" runat="server" onclick="LinkButton1_Click"> LinkButton </asp:linkbutton>

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">


            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <%--<h4 class="modal-title">Modal Header</h4>--%>
                </div>
                <div class="modal-body">

                    <section class="main_cal">

                        <div class="row">
                            <center>
<h3 class="m-y-0 m-b-2"> 
    <i class="fa fa-calendar"></i> Add assets</h3></center>

                            <div class="col-md-8 col-md-offset-2">
                                <div class="main_cal_box">
                                    <div class="row">

                                        <div class="form-group col-md-6">
                                            <div>
                                                Assest Description
                                            </div>
                                            <asp:textbox id="txtNewDesp" textmode="MultiLine" rows="3" cssclass="form-control" runat="server"></asp:textbox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <div>
                                                Quantity 
                                            </div>
                                            <asp:textbox id="txtNewQty" cssclass="form-control" runat="server"></asp:textbox>
                                        </div>


                                        <div class="form-group col-md-3">
                                            <div>
                                                Cost
                                            </div>
                                            <asp:textbox id="txtNewCost" cssclass="form-control" runat="server"></asp:textbox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-2 col-md-offset-5 text-center margintop5">
                                            <asp:button id="addNewAssets" cssclass="form-control btn-primary" runat="server" text="Add Assets" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>


                    </section>
                </div>
                <div class="modal-footer">

                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>


                </div>
            </div>

        </div>
    </div>
</form>

<%--<link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
<script src="scripts/jquery-3.3.1.min.js"></script>
<script src="scripts/bootstrap.min.js"></script>
<script type="text/javascript">
    //$(document).ready(function () {
    //    //$("#myModal22").modal("hide");

    //  $("#LinkButton1").click(function () {

    //     $("#myModal22").modal("show");

    //  });


    //});

    function openModal() {
        $('#myModal').modal('show');
    }

</script>--%>
