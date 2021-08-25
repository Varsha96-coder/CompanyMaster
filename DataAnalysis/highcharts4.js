var limit = 0;
   function myFunction() {
      limit = prompt("Please enter your value <= 100", 10);
      if(limit != null) {
         document.getElementById("demo").innerHTML =
         "Analysis for " + limit + " business activitiy is:";
            return limit;
       }
    }

    function GroupAgg(data){
      var lim = myFunction();
      var jsonData = [data];
      var obj = [];
      var range = [];
      var obj2 = [];
      var count = [];
      var c = 0;
      var e = 0;
      for(var i in jsonData){
         var key = i;
         var val = jsonData[i];
         for(var j in val){
            var sub_key = j;
            var sub_val = val[j];
            obj[c] = sub_key;
            range[c] = sub_val;
            var d = 0;
            for(var k in sub_val){
               var sub2_key = k;
               var sub2_val = sub_val[k];
               obj2[e] = sub2_key;
               count[e] = sub2_val;
               e++;
               d++;
               //console.log(d+"  "+sub2_key+"  "+sub2_val);
            }
            c++;
            //console.log(c+"  "+sub_key+"  "+sub_val);
         }
         console.log(obj);
         console.log(range);
         console.log(obj2);
         console.log(count);
   }


   var chart = {
      type: 'bar'
   };
   var title = {
      text: ' Company Registration by principal business activity (for the year 2000 to 2019)'   
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
         text: 'Population (millions)',
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

  /*var series = [
     {
        name : other business activity
        data: [21,31,........]
     }
     {
        name
        data
     }
  ] */
   var series = [];
   for(var i = 0; i < lim; i++){
      var keys = obj2[i];
      var info = [];
      var e = 0;
      for(var j = 0; j < obj2.length ; j++){
         if(obj2[i] == obj2[j]){
            info[e] = count[j];
            e++;
         }
      }
     console.log(keys);
     console.log(info);
      var dict = {
         name: keys,
         data: info
      }
      console.log(dict);
      series.push(dict);
   }
   console.log(series);

   var json = {};   
   json.chart = chart; 
   json.title = title;   
   json.subtitle = subtitle; 
   json.tooltip = tooltip;
   json.xAxis = xAxis;
   json.yAxis = yAxis;  
   json.plotOptions = plotOptions;
   json.legend = legend;
   json.credits = credits;
   json.series = series; 
   $('#container4').highcharts(json);
}

fetch('GroupAgg.json')
  .then(response => response.json())
  .then(data => GroupAgg(data));

