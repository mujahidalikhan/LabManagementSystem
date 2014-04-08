



/* Ie7 z-index fix */
$(function() {
    var zIndexNumber = 1000;
    $('div').each(function() {
        $(this).css('zIndex', zIndexNumber);
        zIndexNumber -= 10;
    });
});



/* Form Style */
$(function(){

$(".st-forminput").focus(function(){

$(this).attr('class','st-forminput-active ');

});

$(".st-forminput").blur(function(){

$(this).attr('class','st-forminput');

});

});




/* Login Input Form */
$(function(){

$(".login-input-pass").focus(function(){

$(this).attr('class','login-input-pass-active ');

});

$(".login-input-pass").blur(function(){

$(this).attr('class','login-input-pass');

});

});
$(function(){

$(".login-input-user").focus(function(){

$(this).attr('class','login-input-user-active ');

});

$(".login-input-user").blur(function(){

$(this).attr('class','login-input-user');

});

});




	




/* iphone style switches */
	$(document).ready( function(){ 
		$(".cb-enable").click(function(){
			var parent = $(this).parents('.switch');
			$('.cb-disable',parent).removeClass('selected');
			$(this).addClass('selected');
			$('.checkbox',parent).attr('checked', true);
		});
		$(".cb-disable").click(function(){
			var parent = $(this).parents('.switch');
			$('.cb-enable',parent).removeClass('selected');
			$(this).addClass('selected');
			$('.checkbox',parent).attr('checked', false);
		});
	});


