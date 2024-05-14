
@Code
    ViewData("Title") = "Location"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Find Nearest Store</h2>

<p id="status"></p>

<button id="findNearestStoreButton">Find Nearest Store</button>

<p id="result"></p>

    <script>
        document.getElementById("findNearestStoreButton").addEventListener("click", function () {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            } else {
                document.getElementById("status").innerText = "Geolocation is not supported by this browser.";
            }
        });

        function showPosition(position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;
            document.getElementById("status").innerText = "Latitude: " + latitude + ", Longitude: " + longitude;

            // Send latitude and longitude to the server using AJAX
            $.ajax({
                url: '@Url.Action("FindNearest", "users")',
                type: 'POST',
                data: JSON.stringify({ latitude: latitude, longitude: longitude }),
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    document.getElementById("result").innerHTML = response.message;
                },
                error: function () {
                    document.getElementById("result").innerText = "An error occurred while finding the nearest store.";
                }
            });
        }

        function showError(error) {
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    document.getElementById("status").innerText = "User denied the request for Geolocation.";
                    break;
                case error.POSITION_UNAVAILABLE:
                    document.getElementById("status").innerText = "Location information is unavailable.";
                    break;
                case error.TIMEOUT:
                    document.getElementById("status").innerText = "The request to get user location timed out.";
                    break;
                case error.UNKNOWN_ERROR:
                    document.getElementById("status").innerText = "An unknown error occurred.";
                    break;
            }
        }
    </script>





