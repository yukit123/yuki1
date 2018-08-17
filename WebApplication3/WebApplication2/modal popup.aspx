<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modal popup.aspx.cs" Inherits="WebApplication2.modal_popup" %>

<!DOCTYPE html>
<html>
<head>
    <title>Bootstrap </title>
 <link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
<script src="scripts/jquery-3.3.1.min.js"></script>
<script src="scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h2>modal</h2>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close"
                            data-dismiss="modal" aria-hidden="true">
                            &times;
                        </button>
                        <h4 class="modal-title" id="myModalLabel">title
                        </h4>
                    </div>
                    <div class="modal-body">
                        something
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default"
                            data-dismiss="modal">
                            close
                        </button>
                        <button type="button" class="btn btn-primary">
                            save
                        </button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal -->
        </div>
    </form>
</body>

</html>