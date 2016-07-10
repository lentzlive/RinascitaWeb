<%@ Page Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Telemetry.aspx.cs" Inherits="RinascitaWeb.site.Telemetry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- **********************************************************************************************************************************************************
      MAIN CONTENT
      *********************************************************************************************************************************************************** -->
    <!--main content start-->
    <section id="main-content">
        <section class="wrapper">
            <h3><i class="fa fa-angle-right"></i>Telemetry Charts</h3>

            <div class="flot-chart">
                <div class="row mt">




                    <div class="col-lg-12">

                        <div class="content-panel">

                            <h4><i class="fa fa-angle-right"></i>G acceleration</h4>
                            <div class="panel-body">
                                <div id="hero-graph" class="graph" style="position: relative;">
                                </div>


                            </div>

                        </div>
                    </div>

                    
                    <div class="col-lg-12">

                        <div class="content-panel">

                            <h4><i class="fa fa-angle-right"></i>Roll/Pitch</h4>
                            <div class="panel-body">
                                <div id="roll-graph" class="graph" style="position: relative;">
                                </div>


                            </div>

                        </div>
                    </div>


                            
                    <div class="col-lg-12">

                        <div class="content-panel">

                            <h4><i class="fa fa-angle-right"></i>Route</h4>
                            <div class="panel-body">
                                <div id="map" class="graph" style="position: relative;">
                                </div>


                            </div>

                        </div>
                    </div>


                    <!-- /row -->



                    <!-- /col-lg-9 END SECTION MIDDLE -->


                </div>
                <! --/row -->
            </div>
        </section>
    </section>

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.css">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.min.js"></script>

    <script>

        new Morris.Line({
            // ID of the element in which to draw the chart.
            element: 'hero-graph',
         
            <%= _dataForChart %>    
            ,
            // The name of the data record attribute that contains x-values.
            xkey: 'd',
            // A list of names of data record attributes that contain y-values.
            ykeys: ['Xg', 'Yg', 'Zg'],
            // Labels for the ykeys -- will be displayed when you hover over the
            // chart.
            labels: ['Xg', 'Yg', 'Zg'],
            pointSize: 2,
            lineWidth: 1,
            hideHover: 'auto'
        });

                new Morris.Line({
            // ID of the element in which to draw the chart.
            element: 'roll-graph',
         
            <%= _dataRollForChart %>    
            ,
            // The name of the data record attribute that contains x-values.
            xkey: 'd',
            // A list of names of data record attributes that contain y-values.
            ykeys: ['Roll', 'Pitch'],
            // Labels for the ykeys -- will be displayed when you hover over the
            // chart.
            labels: ['Roll', 'Pitch'],
            pointSize: 2,
            lineWidth: 1,
            hideHover: 'auto'
        });

    </script>
    <!--main content end-->


     <script>

      // This example creates a 2-pixel-wide red polyline showing the path of William
      // Kingsford Smith's first trans-Pacific flight between Oakland, CA, and
      // Brisbane, Australia.

      function initMap() {
          var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 3,
          center: {lat: 0, lng: -180},
          mapTypeId: google.maps.MapTypeId.TERRAIN
        });

        var flightPlanCoordinates = [
          {lat: 37.772, lng: -122.214},
          {lat: 21.291, lng: -157.821},
          {lat: -18.142, lng: 178.431},
          {lat: -27.467, lng: 153.027}
        ];
        var flightPath = new google.maps.Polyline({
          path: flightPlanCoordinates,
          geodesic: true,
          strokeColor: '#FF0000',
          strokeOpacity: 1.0,
          strokeWeight: 2
        });

        flightPath.setMap(map);
      }
    </script>
    <script async defer    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAbAmQxuLaNSUH-ydt1Q1UTHiiecv9KLYQ&callback=initMap">    </script>



</asp:Content>
