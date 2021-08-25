$(document).ready(function() {
    /*var chart = {
       type: 'column'
    };
    var title = {
       text: 'number of companies whose "Authorized Cap" falls in the following intervals'   
    };    
    var subtitle = {
       text: 'Source: <a href = "http://en.wikipedia.org/wiki/List_of_cities_proper_by_population">Wikipedia</a>'
    };
    var xAxis = {
       type: 'category',
       labels: {
          rotation: -45,
          style: {
             fontSize: '13px',
             fontFamily: 'Verdana, sans-serif'
          }
       }
    };
    var yAxis = {
       min: 0,
       title: {
         text: 'Authorized Capital'
       }
    };  
    var tooltip = {
        headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
        pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>'
        
    };   
    var credits = {
       enabled: false
    };
    var series = [
       {
          name: 'Companies',
          colorByPoint: true,
          
         data: [
             /*['<= 1L', 185604],
             ['1L to 10L', 140985],
             ['10L to 1Cr', 62697],
             ['1Cr to 10Cr', 27507],
             ['>10Cr', 9470],
            {
                name: "<= 1L",
                y: 185604,
            },
            {
                name: "1L to 10L",
                y: 140985,
            },
            {
                name: "10L to 1Cr",
                y: 62697,
            },
            {
                name: "1Cr to 10Cr",
                y: 27507,
            },
            {
                name: ">10Cr",
                y: 9470,
            },
                
          ],
          dataLabels: {
             enabled: true,
             rotation: -90,
             color: '#FFFFFF',
             align: 'right',
             format: '{point.y:.1f}', // one decimal
             y: 50, // 10 pixels down from the top
             
             style: {
                fontSize: '13px',
                fontFamily: 'Verdana, sans-serif'
             }
          }
       }
    ];     
       
    var json = {};   
    json.chart = chart; 
    json.title = title;   
    json.subtitle = subtitle;
    json.xAxis = xAxis;
    json.yAxis = yAxis;   
    json.tooltip = tooltip;   
    json.credits = credits;
    json.series = series;
    $('#container').highcharts(json);*/


    var chart = {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false
     };
     var title = {
        text: 'Number of companies whose "Authorized Cap" falls in the following intervals'   
     };
     var tooltip = {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
     };
     var plotOptions = {
        pie: {
           allowPointSelect: true,
           cursor: 'pointer',
           
           dataLabels: {
              enabled: true,
              format: '<b>{point.name}%</b>: {point.percentage:.1f} %',
              style: {
                 color: (Highcharts.theme && Highcharts.theme.contrastTextColor)||
                 'black'
              }
           }
        }
     };
     var series = [{
        type: 'pie',
        name: 'Browser share',
        data: [
           
            {
                name: "<= 1L",
                y: 185604,
                sliced: true,
                selected: true
            },
            {
                name: "1L to 10L",
                y: 140985,
                sliced: true,
                selected: true
            },
            {
                name: "10L to 1Cr",
                y: 62697,
                sliced: true,
                selected: true
            },
            {
                name: "1Cr to 10Cr",
                y: 27507,
                sliced: true,
                selected: true
            },
            {
                name: ">10Cr",
                y: 9470,
                sliced: true,
                selected: true
            },
        ]
     }];
     var json = {};   
     json.chart = chart; 
     json.title = title;     
     json.tooltip = tooltip;  
     json.series = series;
     json.plotOptions = plotOptions;
     $('#container').highcharts(json);  

/*-------------------------------------------------------------------------------------------------------------------------------*/
var title = {
    text: 'Company Registration by Year (From 2000 to 2019)'   
 };
 var subtitle = {
    text: 'Source: WorldClimate.com'
 };
 var xAxis = {
    categories: ['2000', '2001', '2002', '2003', '2004', '2005',
       '2006', '2007', '2008', '2009', '2010', '2011','2012','2013','2014','2015','2016','2017','2018','2019']
 };
 var yAxis = {
    title: {
       text: 'Frequency (\xB0C)'
    }
 };
 var plotOptions = {
    line: {
       dataLabels: {
          enabled: true
       },   
       enableMouseTracking: false
    }
 };
     var series = [{
        name: 'Year',
        /*data: []*/
        data:[ 8921, 5055, 4986,6602,8123,9929,9233,12318,14078,10741,16380,17312,17312,16239,12282,14745,17108,19164,22009,23982],
        /*data :fetch('C://Users//Acer//source//repos//CsvToJson//Business.json')
            .then(res => res.json())
            .then((out) => {
                console.log('Output: ', out);
        }).catch(err => console.error(err))*/
    }];      

     var json = {};
     
     json.title = title;
     json.subtitle = subtitle;
     json.xAxis = xAxis;
     json.yAxis = yAxis;  
     json.series = series;
     json.plotOptions = plotOptions;
     $('#container2').highcharts(json);
 });