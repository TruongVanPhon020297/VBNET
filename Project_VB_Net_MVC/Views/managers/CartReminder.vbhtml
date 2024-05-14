@ModelType List(Of user)


@Code
    ViewData("Title") = "CartReminder"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <style>
        body {
            font-family: "Lato", sans-serif;
        }

        .sidebar {
            height: 100%;
            width: 200px;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
            background-color: #111;
            overflow-x: hidden;
            padding-top: 16px;
        }

            .sidebar a {
                padding: 6px 8px 6px 16px;
                text-decoration: none;
                font-size: 20px;
                color: #818181;
                display: block;
                margin: 5px 0;
            }

                .sidebar a:hover {
                    color: #f1f1f1;
                }

        .main {
            margin-left: 200px;
            padding: 0px 10px;
        }
    </style>
</head>
<body>

    <div class="sidebar">
        <a href="http://localhost:53005/Manager/HomePage"><i class="fa fa-fw fa-home"></i> Home</a>
        <a href="http://localhost:53005/Manager/CartReminderPage"><i class="fa fa-envelope-o" aria-hidden="true"></i> Cart Reminder</a>
        <a href="http://localhost:53005/Manager/PostPage"><i class="fa fa-pencil" aria-hidden="true"></i> Post</a>
        <a href="http://localhost:53005/Manager/OrderPage"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Order</a>
        <a href="http://localhost:53005/Manager/CustomOrderPage"><i class="fa fa-cart-plus" aria-hidden="true"></i> Custom order</a>
        <a href="http://localhost:53005/Manager/PurchaseOrderPage"><i class="fa fa-money" aria-hidden="true"></i> Purchase Order</a>
        <a href="http://localhost:53005/Manager/ListUser"><i class="fa fa-fw fa-user"></i> Users</a>
        <a href="http://localhost:53005/Manager/ProductPage"><i class="fa fa-picture-o" aria-hidden="true"></i> Product</a>
        <a href="http://localhost:53005/Manager/Ingredient"><i class="fa fa-superpowers" aria-hidden="true"></i> Ingredient</a>
        <a href="http://localhost:53005/Manager/UserInfo"><i class="fa fa-info-circle" aria-hidden="true"></i> Info</a>
        <a href="http://localhost:53005/Users/Logout"><i class="fa fa-sign-out" aria-hidden="true"></i> Logout</a>
    </div>

    <div class="main">
        <div>
            <div class="row">
                @Using Html.BeginForm("CartReminder", "Manager")
                    @Html.AntiForgeryToken()
                    @<div Class="col-xs-12 col-sm-12">
                        <div Class="panel panel-default">
                            <div Class="panel-heading">
                                <h4 Class="panel-title">Email Info</h4>
                            </div>
                            <div Class="panel-body">

                                <div Class="form-group">
                                    <Label Class="col-sm-2 control-label">User</Label>
                                    <div Class="col-sm-10" style="margin-top:10px">
                                        <select Class="form-control" name="mailTo" aria-label="Default select example">
                                            @If Model.Count > 0 Then
                                                For Each item In Model
                                                    @<option value = "@item.email" >@item.email</option>
                                                Next
                                            End If
                                            
                                        </select>
                                    </div>
                                </div>

                                <div Class="form-group">
                                    <Label Class="col-sm-2 control-label">Content</Label>
                                    <div Class="col-sm-10" style="margin-top:10px">
                                        <textarea rows="10" Class="form-control" name="content"></textarea>
                                    </div>
                                </div>

                                <div Class="form-group">
                                    <div Class="col-sm-10 col-sm-offset-2" style="margin-top:10px">
                                        <Button type="submit" Class="btn btn-primary">Create</Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                End Using
            </div>
        </div>
    </div>

</body>
</html>