<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>OTP verification UI using bootstrap</title>

    <!-- bootstrap 5 stylesheet -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.1/css/bootstrap.min.css" integrity="sha512-Ez0cGzNzHR1tYAv56860NLspgUGuQw16GiOOp/I2LuTmpSK9xDXlgJz3XN4cnpXWDmkNBKXR/VDMTCnAaEooxA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <!-- fontawesome 6 stylesheet -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.3.0/css/all.min.css" integrity="sha512-SzlrxWUlpfuzQ+pcUCosxcglQRNAq/DZjVsC0lE40xsADsfeQoEypE+enwcOiGjk/bSuGGKHEyjSoQ1zVisanQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />


    <style>
        body {
            background-color: #ebecf0;
        }

        .otp-letter-input {
            max-width: 100%;
            height: 90px;
            border: 1px solid #198754;
            border-radius: 10px;
            color: #198754;
            font-size: 60px;
            text-align: center;
            font-weight: bold;
        }

        .btn {
            height: 50px;
        }
    </style>
</head>
<body>
    <div class="container p-5">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-5 mt-5">
                <div class="bg-white p-5 rounded-3 shadow-sm border">
                    <div>
                        <p class="text-center text-success" style="font-size: 5.5rem;"><i class="fa fa-mobile" aria-hidden="true"></i></p>
                        <p class="text-center text-center h5 ">Please check your phone</p>
                        <p class="text-muted text-center">We've sent a code to contact@curfcode.com</p>
                        @Using (Html.BeginForm("SendOTP", "users"))
                            @Html.AntiForgeryToken()
                            @<div Class="row pt-4 pb-2">
                                <div Class="col-12">
                                    <input Class="otp-letter-input" type="text" name="phone">
                                </div>
                            </div>
                            @<div Class="row pt-5">
                                <div Class="col-12">
                                    <Button type="submit" Class="btn btn-success w-100">Send</Button>
                                </div>
                            </div>
                        End Using
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
