function AuthorCap(data){
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

        var title = {
            text: 'No.of companies in Authorized Capital according to ranges'   
        };
        var subtitle = {
            text: 'Source: WorldClimate.com'
        };
        var xAxis = {
            categories: obj
            //["<= 1L","1L to 10L","10L to 1Cr","1Cr to 10Cr", ">10Cr"]
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
            data: range
            //[185604,140985,62697,27507,9470]        
         }] 

         var json = {};
         
         json.title = title;
         json.subtitle = subtitle;
         json.xAxis = xAxis;
         json.yAxis = yAxis;  
         json.series = series;
         json.plotOptions = plotOptions;
         $('#container').highcharts(json);
}


fetch('AuthorCap.json')
  .then(response => response.json())
  .then(data => AuthorCap(data));
