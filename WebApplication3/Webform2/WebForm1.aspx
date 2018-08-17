<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  CodeBehind="WebForm1.aspx.cs" Inherits="Webform2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/jquery.bootstrapvalidator/0.5.3/css/bootstrapValidator.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-validator/0.5.3/js/bootstrapValidator.js"></script>
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
     //function docc() {
     //        alert(11);
     //         $('form').bootstrapValidator({
     //           feedbackIcons: {
     //               valid: 'glyphicon glyphicon-ok',
     //               invalid: 'glyphicon glyphicon-remove',
     //               validating: 'glyphicon glyphicon-refresh'
     //           },
     //           fields: {
     //               txt_Code: {
     //                   validators: {
     //                       notEmpty: {
     //                           message: 'The ID is required and cannot be empty'
     //                       }
     //                   }
     //               },
     //               txt_Description: {
     //                   validators: {
     //                       notEmpty: {
     //                           message: 'The email address is required and cannot be empty'
     //                       }
     //                   }
     //               }
      
     //           }
     //       });
     //   }
    </script>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form id="form1" method="post" runat="server" class="form-horizontal">                
    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="lbl_Code" runat="server" CssClass="col-sm-4 control-label" Text="Code"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txt_Code" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_Description" runat="server" CssClass="col-sm-4 control-label" Text="Description"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txt_Description"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-4"></div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnInsert" CssClass="btn btn-primary"  runat="server" class="btn btn-primary" ValidationGroup="One" Text=" Save Record"></asp:Button>
                            </div>
                        </div>
                    </div>
 </form>
<%--  <script type="text/javascript">
        
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
     //function docc() {
     //        alert(11);
     //         $('#form1').bootstrapValidator({
     //           feedbackIcons: {
     //               valid: 'glyphicon glyphicon-ok',
     //               invalid: 'glyphicon glyphicon-remove',
     //               validating: 'glyphicon glyphicon-refresh'
     //           },
     //           fields: {
     //               txt_Code: {
     //                   validators: {
     //                       notEmpty: {
     //                           message: 'The ID is required and cannot be empty'
     //                       }
     //                   }
     //               },
     //               txt_Description: {
     //                   validators: {
     //                       notEmpty: {
     //                           message: 'The email address is required and cannot be empty'
     //                       }
     //                   }
     //               }
      
     //           }
     //       });
     //   }
    </script>--%>
      </asp:Content>