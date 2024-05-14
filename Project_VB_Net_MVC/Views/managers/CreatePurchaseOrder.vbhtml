@ModelType Tuple(Of List(Of ingredient), List(Of purchased_order_detail), purchased_order)
@Code
    ViewData("Title") = "CreatePurchaseOrder"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<div class="container-fluid">
    @Html.ActionLink("Back To List", "PurchaseOrderPage", "Manager", Nothing, htmlAttributes:=New With {.class = "btn btn-lg btn-default md-btn-flat mt-2 mr-3"})
    <div class="row">
        <div class="col-md-9">
            <div class="container">
                <div class="row" style="margin-bottom: 10px">
                    <div Class="col-xl-8">
                        <div Class="card mb-4">
                            @Using (Html.BeginForm("CreatePurchaseOrder", "Manager"))
                                @Html.AntiForgeryToken()
                                @<div Class="card-body">
                                    <div Class="row gx-3 mb-3">
                                        <div Class="col-md-6">
                                            <Label Class="small mb-1" for="inputOrgName">Ingredient</Label>
                                            <select Class="form-control" name="ingredientId" aria-label="Default select example">
                                                @If Model IsNot Nothing Then
                                                    @For Each item In Model.Item1
                                                        @<option value="@item.id">@item.ingredient_name</option>
                                                    Next
                                                End If
                                            </select>
                                        </div>
                                    </div>
                                    <div Class="row gx-3 mb-3">
                                        <div Class="col-md-6">
                                            <Label Class="small mb-1" for="inputOrgName">Quantity</Label>
                                            <input Class="form-control" id="inputOrgName" name="quantity" type="number" value="">
                                        </div>
                                    </div>
                                    <div Class="row gx-3 mb-3">
                                        <div Class="col-md-6">
                                            <Button Class="btn btn-primary" type="submit" style="margin-top:20px">Add</Button>
                                        </div>
                                    </div>
                                </div>
                            End Using
                        </div>
                    </div>
                </div>
                <div Class="row">
                    <div Class="col-12 mb-3 mb-lg-5">
                        <div Class="overflow-hidden card table-nowrap table-card">
                            <div Class="table-responsive table-wrapper">
                                <Table Class="table mb-0" style="margin-top:10px">
                                    <thead Class="small text-uppercase bg-body text-muted">
                                        <tr>
                                            <th> INGREDIENT NAME</th>
                                            <th> INGREDIENT CATEGORY</th>
                                            <th> QUANTITY</th>
                                            <th> PRICE</th>
                                            <th Class="text-end">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        @If Model.Item2 IsNot Nothing Then
                                            @For Each item In Model.Item2
                                                @<tr>
                                                    <td>@item.ingredient_name</td>
                                                    <td>@item.ingredient_category_id </td>
                                                    <td>@item.quantity  </td>
                                                    <td>

                                                        @Using (Html.BeginForm("UpdatePrice", "Manager"))
                                                            @Html.AntiForgeryToken()
                                                            @<input Class="form-control" id="inputOrgName" name="price" type="number" value="@item.price">
                                                            @<div class="form-inline my-2 my-lg-0" style="margin-bottom:20px;margin-top:10px">
                                                                @Html.TextBox("detailId", item.id, htmlAttributes:=New With {.class = "form-control mr-sm-2", .style = "display: none;"})
                                                                @Html.TextBox("orderId", item.purchased_order_id, htmlAttributes:=New With {.class = "form-control mr-sm-2", .style = "display: none;"})
                                                                <button type="submit" class="btn btn-success"><i class="fa fa-check" aria-hidden="true"></i></button>
                                                            </div>
                                                        End Using
                                                    </td>
                                                    <td>
                                                        <div Class="drodown">
                                                            @Using (Html.BeginForm("DeleteDetail", "Manager"))
                                                                @Html.AntiForgeryToken()
                                                                @<div class="form-inline my-2 my-lg-0" style="margin-bottom:20px;margin-top:10px">
                                                                    @Html.TextBox("detailId", item.id, htmlAttributes:=New With {.class = "form-control mr-sm-2", .style = "display: none;"})
                                                                    @Html.TextBox("orderId", item.purchased_order_id, htmlAttributes:=New With {.class = "form-control mr-sm-2", .style = "display: none;"})
                                                                    <button type="submit" class="btn btn-danger"><i class="fa fa-trash-o" aria-hidden="true"></i></button>
                                                                </div>
                                                            End Using
                                                        </div>
                                                    </td>
                                                </tr>
                                            Next
                                        End If
                                    </tbody>
                                </Table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    @If Model.Item3 IsNot Nothing Then
        @Using (Html.BeginForm("CheckoutPurchaseOrder", "Manager"))
            @Html.AntiForgeryToken()
            @Html.TextBox("orderId", Model.Item3.id, htmlAttributes:=New With {.class = "form-control mr-sm-2", .style = "display: none;"})
            @<div Class="card-body">
                <div Class="row gx-3 mb-3">
                    <div Class="col-md-6">
                        <Label Class="small mb-1" for="inputOrgName">Total Quantity</Label>
                        <div>
                            @Model.Item3.total_quantity
                        </div>
                    </div>
                </div>
                <div Class="row gx-3 mb-3">
                    <div Class="col-md-6">
                        <Label Class="small mb-1" for="inputOrgName">Total Price</Label>
                        <div>@Model.Item3.total_price</div>
                    </div>
                </div>
                <div Class="row gx-3 mb-3">
                    <div Class="col-md-6">
                        <Button Class="btn btn-primary" type="submit" style="margin-top:20px">Checkout</Button>
                    </div>
                </div>
            </div>
        End Using
    End If
</div>