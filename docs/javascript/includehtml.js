
function includeHTML() {
  var z, i, elmnt, file, xhttp;
  /*loop through a collection of all HTML elements:*/
  z = document.getElementsByTagName("*");
  for (i = 0; i < z.length; i++) {
    elmnt = z[i];
    /*search for elements with a certain atrribute:*/
    file = elmnt.getAttribute("w3-include-html");
    if (file) {
      /*make an HTTP request using the attribute value as the file name:*/
      xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4) {
          if (this.status == 200) {elmnt.innerHTML = this.responseText;}
          if (this.status == 404) {elmnt.innerHTML = "Page not found.";}
          /*remove the attribute, and call this function once more:*/
          elmnt.removeAttribute("w3-include-html");
          includeHTML();
        }
      }      
      xhttp.open("GET", file, true);
      xhttp.send();
      /*exit the function:*/
      return;
    }
  }
};


document.getElementById("myHead").innerHTML =
  "<span id='headerText'>Title</span>"
  + "<span id='headerSubtext'>Subtitle</span>";
document.getElementById("myNav").innerHTML =
  "<ul id='navLinks'>"
  + "<li><a href='index.html'>Home</a></li>"
  + "<li><a href='about.html'>About</a>"
  + "<li><a href='donate.html'>Donate</a></li>"
  + "</ul>";
document.getElementById("footer").innerHTML ='<div class="container ">'
+'<a href="#hero" class="back-to-top" aria-label="go back to top">'
+'<i class="fa fa-angle-up fa-2x" aria-hidden="true"></i>'
 +'</a><div class="social-links">'
 +'<a href="https://twitter.com/elshindr" target="_blank" rel="noopener noreferrer" aria-label="twitter">'
 +'<i class="fa fa-twitter"></i></a>'
 +'<a href="https://www.linkedin.com/in/noelinemarie/" target="_blank" rel="noopener noreferrer" aria-label="linkedin">'
 +'<i class="fa fa-linkedin"></i></a><a href="https://github.com/Elshindr" target="_blank" rel="noopener noreferrer" aria-label="github">'
 +'<i class="fa fa-github"></i></a></div><hr /><p class="footer__text"> &copy; <span id="year">'
 +'</span> - Template by <a href="https://github.com/AnilSeervi" target="_blank" rel="noopener noreferrer">Anil Seervi</a>. <br />Made with &hearts;</p></div>;';
  
  
  document.getElementById("vvfooter").innerHTML ='<p>merrrrrrrrrrrrrrrrrrrrrrde</p>';
   