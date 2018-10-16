$.ajax({
  url: "http://www.baidu.com",
  context: document.body,
  success: function(data){
 //   util.log(data);
    
    var result =parseHtml(data);
    
    var $v= jQuery(result);
 //   util.log(result);
    $v.find('#u a').each(function(index) {
         util.log(index + ': ' + $(this).attr("href"));
  //        arr.add($(this).attr("href"));
    });
  }
});


 function parseHtml(html) {
       //Create an iFrame object that will be used to render the HTML in order to get the DOM objects
        //created - this is a far quicker way of achieving the HTML to DOM conversion than trying
        //to transform the HTML objects one-by-one
         var oIframe = document.createElement('iframe');
     //Hide the iFrame from view
         oIframe.style.display = 'none';
         if (document.body)
            document.body.appendChild(oIframe);
        else
            document.documentElement.appendChild(oIframe);
        
        //Open the iFrame DOM object and write in our HTML
        oIframe.contentDocument.open();
        oIframe.contentDocument.write(html);
        oIframe.contentDocument.close();
    
        //Return the document body object containing the HTML that was just
        //added to the iFrame as DOM objects
        var oBody = oIframe.contentDocument.body;
    
        //TODO: Remove the iFrame object created to cleanup the DOM
    
        return oBody;
    }