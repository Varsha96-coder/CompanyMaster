function Business(data){
    var jsonData = [data];
    var obj = [];
    var range = [];
    var c = 0;
        for(var i in jsonData){
            var key = i;
            var val = jsonData[i];
            for(var j in val){
                var sub_key = j;
                var sub_val = val[j];
                obj[c] = sub_key;
                range[c] = sub_val;
                c++;
                console.log(c+"  "+sub_key+"  "+sub_val);
            }
            console.log(obj);
            console.log(range);
        }
    

        var chart = {
            type: 'bar'
         };
         var title = {
            text: ' Company Registration by principal business activity (for the year 2015)'   
         };
         var subtitle = {
            text: 'Source: Wikipedia.org'  
         };
         var xAxis = {
            categories: obj,
            title: {
               text: null
            }
         };
         var yAxis = {
            min: 0,
            title: {
               text: 'Companies Population',
               align: 'high'
            },
            labels: {
               overflow: 'justify'
            }
         };
         var tooltip = {
            valueSuffix: ' millions'
         };
         var plotOptions = {
            bar: {
               dataLabels: {
                  enabled: true
               }
            }
         };
         var legend = {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 100,
            floating: true,
            borderWidth: 1,
            
            backgroundColor: (
               (Highcharts.theme && Highcharts.theme.legendBackgroundColor) ||
                  '#FFFFFF'),
            shadow: true
         };
         var credits = {
            enabled: false
         };
         var series = [
            {
               name: 'Year 1500',
               data: range
            }, 
         ];
   
         var json = {};   
         json.chart = chart; 
         json.title = title;   
         json.subtitle = subtitle; 
         json.tooltip = tooltip;
         json.xAxis = xAxis;
         json.yAxis = yAxis;  
         json.series = series;
         json.plotOptions = plotOptions;
         json.legend = legend;
         json.credits = credits;
         $('#container3').highcharts(json);
}
fetch('Business.json')
  .then(response => response.json())
  .then(data => Business(data));
