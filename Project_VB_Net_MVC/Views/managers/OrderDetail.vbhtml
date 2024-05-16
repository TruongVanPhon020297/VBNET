@ModelType Tuple(Of List(Of order_detail), order, UserLock, delivery)
@Code
    ViewData("Title") = "OrderDetail"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f0f0f0;
    }

    .alert-container {
        width: 400px;
        margin: 100px auto;
        background-color: #fff;
        border: 1px solid #ccc;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        padding: 20px;
    }

    .alert-title {
        font-size: 20px;
        margin-bottom: 10px;
    }

    .alert-message {
        margin-bottom: 20px;
    }

    .alert-buttons {
        text-align: right;
    }

    .btn {
        padding: 10px 20px;
        background-color: #007bff;
        color: #fff;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        margin-left: 10px;
    }
</style>

@if Model IsNot Nothing Then
    Dim orderDetails As List(Of order_detail) = Model.Item1
    Dim delivery As delivery = Model.Item4
    Dim order As order = Model.Item2
    Dim user As user = Model.Item3.user
    Dim userLock As user = Model.Item3.userLock

    If userLock IsNot Nothing And Model.Item3.flg = False And Not order.status Then
        @<div class="alert-container">
            <div class="alert-title">Thông báo cảnh báo</div>
            <div class="alert-message">Dữ liệu đang được @userLock.full_name sử dụng, bạn không thể thao tác trên dữ liệu này  </div>
            <div class="alert-buttons">
                <button class="btn" onclick="closeAlert()">Đồng ý</button>
            </div>
        </div>
    End If

    If Model.Item3.flg = False  Then
        @Html.ActionLink("ORDER PAGE", "OrderPage", "Manager", New With {.class = "btn btn-info"})
    Else
        @Html.ActionLink("ORDER PAGE", "OrderPageRollBack", "Manager", New With {.orderId = order.id}, New With {.class = "btn btn-info"})
    End If


    @<div class="container px-3 my-5 clearfix">
        
        <div class="card">
            <div class="card-header">
                <h2>Order Detail</h2>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered m-0">
                        <thead>
                            <tr>
                                
                                <th class="text-center py-3 px-4" style="min-width: 400px;">Product Name &amp; Details</th>
                                <th class="text-right py-3 px-4" style="width: 100px;">Price</th>
                                <th class="text-center py-3 px-4" style="width: 120px;">Quantity</th>
                                <th class="text-right py-3 px-4" style="width: 100px;">Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each detail In orderDetails
                                @<tr>
                                    <td class="p-4">
                                        <div class="media align-items-center">
                                            <img src="@Url.Content("~/Uploads/" & detail.image)" width="200" height="200" class="d-block ui-w-40 ui-bordered mr-4" alt="">
                                            <div class="media-body">
                                                <a href="#" class="d-block text-dark">@detail.product_name</a>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="text-right font-weight-semibold align-middle p-4">$@detail.price</td>
                                    <td class="align-middle p-4">
                                        @detail.quantity
                                    </td>
                                    <td class="text-right font-weight-semibold align-middle p-4">$@detail.total_price</td>
                                </tr>
                            Next
                        </tbody>
                    </table>
                </div>

                <div class="d-flex flex-wrap justify-content-between align-items-center pb-4">
                    <div class="d-flex">
                        <div class="text-right mt-4 mr-5">
                            <label class="text-muted font-weight-normal m-0">Quantity</label>
                            <div class="text-large"><strong>@order.quantity</strong></div>
                        </div>
                        <div class="text-right mt-4">
                            <label class="text-muted font-weight-normal m-0">Total price</label>
                            <div class="text-large"><strong>$@order.total_price</strong></div>
                        </div>
                    </div>
                </div>

                @Using (Html.BeginForm("ConfirmOrder", "Manager"))
                    @Html.AntiForgeryToken()
                    @<input type="hidden" name="orderId" value="@order.id" />
                    @<Label Class="text-muted font-weight-normal">Full Name</Label>
                    @<div>@user.full_name</div>
                    @<Label Class="text-muted font-weight-normal">Delivery</Label>
                    @<div>@delivery.location</div>
                    @<Label Class="text-muted font-weight-normal">Phone</Label>
                    @<div>@delivery.phone</div>
                    @If order.status = True Then
                        @<Label Class="text-muted font-weight-normal">Delivery Date</Label>
                        @<div>@delivery.delivery_date.Value.ToShortDateString()</div>
                    End If
                    @If Not order.status And Model.Item3.flg Then
                        @<div Class="row gx-3 mb-3">
                            <div Class="col-md-6">
                                <Label Class="text-muted font-weight-normal">Delivery Date</Label>
                                <input Class="form-control" id="inputBirthday" type="date" name="deliveryDate" value="@Date.Now().ToShortDateString()" />
                            </div>
                        </div>
                        @<div Class="float-right" style="margin-top:10px">
                            <input type="submit" value="Confirm" class="btn btn-lg btn-default md-btn-flat mt-2 mr-3" />
                        </div>
                    End If
                End Using
            </div>
        </div>
    </div>
End If


<script>
    function closeAlert() {
        document.querySelector('.alert-container').style.display = 'none';
    }
</script>