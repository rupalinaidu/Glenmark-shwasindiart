	   if(!localStorage.getItem("emp_no")){
		   
		   //window.location.href = "../index.html";
	   }
	   
	   
		var emp_no = localStorage.getItem("emp_no");
		var name =  localStorage.getItem("name");
		var zone =  localStorage.getItem("zone");
		var region =  localStorage.getItem("region");
		var state = localStorage.getItem("state");
		var desg = localStorage.getItem("desg");
		var hq = localStorage.getItem("hq");
		var email = localStorage.getItem("email");
		var reportingto = localStorage.getItem("reportingto");
		
		
		  
$(document).ready(function() {
//alert(name);
		
    $("#username").html(name);
	if(desg=="ZBM" || desg=="ADMIN" || desg=="RBM"  || desg=="SR.ABM"  || desg=="SR.RBM"){
			//$(".navsenior").show();		
		}
		
	$(document).on('click','.logout_btn', function(){
		localStorage.setItem("emp_no","");
	  localStorage.setItem("name","");
	   localStorage.setItem("zone","");
	   localStorage.setItem("region","");
	   localStorage.setItem("state","");
	   localStorage.setItem("desg","");
	   localStorage.setItem("hq","");
	   localStorage.setItem("email","");
	   localStorage.setItem("reportingto","");
	   
	   window.location.href = "../index.html";
		
	});

});

function bindselect(ajaxurl, ddidname) {
	//alert(ddidname);
	var myjson = [];
	var errorflag = [];
	$.getJSON(ajaxurl, { format: "json" }).done(function (data) {
		myjson = data.dataObject;

		errorflag = data.code;
		if (errorflag === "500") {
			$('#' + errordiv).html("<div class='text-center'>Server Side Error .<div>");
		}
		else if (errorflag === "200" & myjson === null) {
			$('#' + errordiv).html("<div class='text-center' style='color:#fff!important;'>Data not available .<div>");
		}
		else {
			if (data.dataObject.length === 0) {
				$('#' + errordiv).css('background-color', 'rgba(244, 67, 54, 0.85)');
				$('#' + errordiv).fadeIn('slow');
				$('#' + errordiv).html("<i class='fa fa-info-circle'></i>&nbsp;&nbsp;<label id='lblerrorpage'> No data available in " + ddidname + " DropDown </label>");
				setTimeout(function () {
					$('#' + errordiv).fadeOut('slow');
				}, 3000);

			}
			else {

				$('#' + ddidname).select2({
					casesensitive: false,
					tags: true,
					data: myjson,
					cache: true,

					delay: 250,
					closeOnSelect: true,
				});
			}
		}
	});
}

function bindselectpost(ajaxurl, ddidname, obj1) {

	var myjson;
	$.ajax({
		url: ajaxurl,
		method: "POST",
		data: JSON.stringify(obj1),
		dataType: 'json',
		contentType: "application/json",

		success: function (data) {
			myjson = data.dataObject;
			if (data.dataObject.length === 0) {
				$('#' + errordiv).css('background-color', 'rgba(244, 67, 54, 0.85)');
				$('#' + errordiv).fadeIn('slow');
				$('#' + errordiv).html("<i class='fa fa-info-circle'></i>&nbsp;&nbsp;<label id='lblerrorpage'> No data available in " + ddidname + " DropDown </label>");
				setTimeout(function () {
					$('#' + errordiv).fadeOut('slow');
				}, 3000);

			}
			else {

				$('#' + ddidname).select2({
					casesensitive: false,
					tags: true,
					data: myjson,
					cache: true,

					delay: 250,
					closeOnSelect: true,
				});
			}

		}
	});

}
//function to check login
function checklogin() {
	var cookieValue = getCook('glenmark_camps').split('&');
	//alert(cookieValue[3]);

	if (typeof cookieValue[3] === 'undefined') {
		window.location.assign("../index.html??msg=Please Login")

	}
	else {
		$("#lbl_username").text(cookieValue[1]);

	}
}


//pop up msg from querystring
function getCook(cookiename) {
	// Get name followed by anything except a semicolon
	var cookiestring = RegExp("" + cookiename + "[^;]+").exec(document.cookie);
	// Return everything after the equal sign, or an empty string if the cookie name not found
	return unescape(!!cookiestring ? cookiestring.toString().replace(/^[^=]+./, "") : "");
}

var urlParams;
(window.onpopstate = function () {
	var match,
		pl = /\+/g,  // Regex for replacing addition symbol with a space
		search = /([^&=]+)=?([^&]*)/g,
		decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
		query = window.location.search.substring(1);

	urlParams = {};
	while (match = search.exec(query))
		urlParams[decode(match[1])] = decode(match[2]);
})();



function getCookies() {
	var cookieMap = {};
	let coo = document.cookie.split(';');
	for (var value of coo.values()) {

		if (value.includes('glenmark_camps=')) {
			var cookie = value.trim().replace('glenmark_camps=', '').split('&');
			cookie.forEach(x => { cookieMap[x.split('=')[0]] = x.split('=')[1] });//x.split('='), cook[x[0] = x[1]]);console.log(x.split('=')[0]), console.log(x.split('=')[1])
			return cookieMap;

		}
	}

	if (coo.values() === 'l') {
		alert('1');
	}

}