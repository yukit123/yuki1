
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modal popup2.aspx.cs" Inherits="WebApplication2.modal_popup2" %>

<head>


<%--    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">--%>
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
<div class="modal fade" id="myAddModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h4 class="modal-title " id="myModalLabel">Add New </h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="lbl_Code" runat="server" CssClass="col-sm-4 control-label" Text="Code"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txt_Code" CssClass="form-control" runat="server" name="Code"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_Description" runat="server" CssClass="col-sm-4 control-label" Text="Description" name="Description"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_Description"  CssClass="form-control" runat="server" name="Description"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-4"></div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnInsert" CssClass="btn btn-primary"  runat="server" class="btn btn-primary" ValidationGroup="One" Text=" Save Record" ></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>        
            </div>
        </div>
    </div>
    </form>

  <form id="tryitForm" class="form-horizontal">
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
    </form>

<%--<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>

    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/jquery.bootstrapvalidator/0.5.3/css/bootstrapValidator.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-validator/0.5.3/js/bootstrapValidator.js"></script>

    <script>
        $(document).ready(function () {
            $('#tryitForm').bootstrapValidator({
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    firstName: {
                        validators: {
                            notEmpty: {
                                message: 'The first name is required and cannot be empty'
                            }
                        }
                    },
                    lastName: {
                        validators: {
                            notEmpty: {
                                message: 'The last name is required and cannot be empty'
                            }
                        }
                    }
                },
                submitHandler: function (validator, form, submitButton) {
                    var fullName = [validator.getFieldElements('firstName').val(),
                    validator.getFieldElements('lastName').val()].join(' ');
                    alert('Hello ' + fullName);
                }
            });
        });
    </script>
</head>
<body>
    <form id="tryitForm" class="form-horizontal">
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
    </form>
</body>
</html>--%>
