@ModelType Tuple(Of List(Of purchased_order_detail), purchased_order)

@Code
    ViewData("Title") = "PurchaseOrderDetail"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div class="container-fluid">
    @Html.ActionLink("Back To List", "PurchaseOrderPage", "Manager", Nothing, htmlAttributes:=New With {.class = "btn btn-lg btn-default md-btn-flat mt-2 mr-3"})
    <div class="row">
        <div class="col-md-9">
            <div class="container">
                <div class="row" style="margin-bottom: 10px">
                    <div Class="col-xl-8">
                        <div Class="card mb-4">
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
                                        </tr>
                                    </thead>
                                    <tbody>
                                        @If Model IsNot Nothing Then
                                            @For Each item In Model.Item1
                                                @<tr>
                                                    <td>@item.ingredient_name</td>
                                                    <td>@item.ingredient_category_id </td>
                                                    <td>@item.quantity</td>
                                                    <td>@item.price</td>
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
    @If Model.Item2 IsNot Nothing Then

        @<div Class="card-body">
            <div Class="row gx-3 mb-3">
                <div Class="col-md-6">
                    <Label Class="small mb-1" for="inputOrgName">Total Quantity</Label>
                    <div>
                        @Model.Item2.total_quantity
                    </div>
                </div>
            </div>
            <div Class="row gx-3 mb-3">
                <div Class="col-md-6">
                    <Label Class="small mb-1" for="inputOrgName">Total Price</Label>
                    <div>@Model.Item2.total_price</div>
                </div>
            </div>
        </div>

    End If
</div>