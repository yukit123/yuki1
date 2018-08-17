<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BootStrap Validation.aspx.cs" Inherits="Webform2.BootStrap_Validation" %>

<head>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/jquery.bootstrapvalidator/0.5.3/css/bootstrapValidator.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-validator/0.5.3/js/bootstrapValidator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#form1').bootstrapValidator({
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    txt_Code: {
                        validators: {
                            notEmpty: {
                                message: 'The ID is required and cannot be empty'
                            }
                        }
                    },
                    txt_Description: {
                        validators: {
                            notEmpty: {
                                message: 'The email address is required and cannot be empty'
                            }
                        }
                    }

                }
            });
        });
    </script>
</head>

<form id="form1" runat="server">
    <%--<div class="modal fade" id="myAddModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h4 class="modal-title " id="myModalLabel">Add New </h4>
                </div>
                <div class="modal-body">--%>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:label id="lbl_Code" runat="server" cssclass="col-sm-4 control-label" text="Code"></asp:label>
            <div class="col-sm-5">
                <asp:textbox id="txt_Code" cssclass="form-control" runat="server"></asp:textbox>
            </div>
        </div>
        <div class="form-group">
            <asp:label id="lbl_Description" runat="server" cssclass="col-sm-4 control-label" text="Description"></asp:label>
            <div class="col-sm-8">
                <asp:textbox id="txt_Description" cssclass="form-control" runat="server"></asp:textbox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                <asp:button id="btnInsert" cssclass="btn btn-primary" runat="server" class="btn btn-primary" validationgroup="One" text=" Save Record"></asp:button>
            </div>
        </div>
    </div>
    <%--                </div>        
            </div>
        </div>
    </div>--%>
</form>

<%--  <form id="tryitForm" class="form-horizontal">
        <div class="form-group">
            <label class="col-md-3 control-label">Full name</label>
            <div class="col-md-4">
                <input type="text" class="form-control" name="firstName" />
            </div>
            <div class="col-md-4">
                <input type="text" class="form-control" name="lastName" />
            </div>
        </div>




        <div class="form-group">
            <div class="col-md-offset-3 col-md-8">
                <button type="submit" class="btn btn-primary">Say hello</button>
            </div>
        </div>
    </form>--%>

