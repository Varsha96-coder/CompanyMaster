function RegYear(data){
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
            text: 'Company Registration by Year (From 2000 to 2019)'   
         };
         var subtitle = {
            text: 'Source: WorldClimate.com'
         };
         var xAxis = {
            categories: obj
            /* ['2000', '2001', '2002', '2003', '2004', '2005',
               '2006', '2007', '2008', '2009', '2010', '2011','2012','2013','2014','2015','2016','2017','2018','2019']*/
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
                data: range
                //[ 8921, 5055, 4986,6602,8123,9929,9233,12318,14078,10741,16380,17312,17312,16239,12282,14745,17108,19164,22009,23982],
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
}
fetch('RegYear.json')
  .then(response => response.json())
  .then(data => RegYear(data));
