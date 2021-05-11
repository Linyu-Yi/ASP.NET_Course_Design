// JavaScript Document
$(function(){
	        $('.explaindiv div p:last-child').css('paddingBottom','15px');
		   	$('.li4').css('border','none');
		   	$('.optionaltab tr:even').css('background','#f1f1f1');
		   	$('.optionaltab tr td:first-child').css('paddingLeft','5px');
		   $('.left ul li').hover(
			  function(){
				  $(this).addClass('libgon');
				  $(this).find('a').css('color','#1abc9c');
				  $(this).find('span').css('color','#1abc9c')
				  },
			  function(){
				   $(this).removeClass('libgon').addClass('libg');
				   $(this).find('a').css('color','#fff');
				   $(this).find('span').css('color','#798795')
				  }			  
			  )	;
		   $('.lists li').hover(function(){
			   $(this).addClass('listsbg');
		   },function(){
			   $(this).removeClass('listsbg');			   
		   });
		   //li1
		   $('.li1').hover(
		   function(){$(this).children('.nav1').addClass('nav1on');},
		   function(){$(this).children('.nav1').removeClass('nav1on').addClass('nav1');});
		   //li2
		   $('.li2').hover(
		   function(){$(this).children('.nav2').addClass('nav2on');},
		   function(){$(this).children('.nav2').removeClass('nav2on').addClass('nav2');});
		   //li3
		   $('.li3').hover(
		   function(){$(this).children('.nav3').addClass('nav3on');},
		   function(){$(this).children('.nav3').removeClass('nav3on').addClass('nav3');});
		   //li4
		   $('.li4').hover(
		   function(){$(this).children('.nav4').addClass('nav4on');},
		   function(){$(this).children('.nav4').removeClass('nav4on').addClass('nav4');});
		    
		    $('.packagetab tr:last-child').css('border','none');
		    $('.txtinput,.txtinput_search,textarea,select').focus(function(){$(this).css('border','1px solid #1eb699')});
			$('.txtinput,.txtinput_search,textarea,select').blur(function(){$(this).css('border','1px solid #e9e7e7')});
		    $('.right_contact1 span select:last-child').css('margin','0');
		    $('.yztab tr td:first-child,.yz_tab tr td:first-child').css({'paddingRight':'10px','textAlign':'right'});
		    $('#cproposals').click(function(){$('.c_proposals').slideToggle();});
			$('#apply').click(function(){$('.applyorder').slideToggle();});
		    
			$(".toggle_container").hide(); 
			$(".trigger").click(function(){
				$(this).toggleClass("active").next().slideToggle("slow");
				return false;
			});
			$('.right_contact3 dl dt').click(function(){
				if($(this).children('b').hasClass('helpx')){
					$(this).children('b').removeClass('helpx').addClass('helps');
					}else{
					$(this).children('b').addClass('helpx').removeClass('helps');
					}
					$(this).next('dd').slideToggle();
					});
			
	//凑整套餐选择
	$(".icon-select").bind('click',function(){
		if($(this).hasClass("return")){
			$(this).removeClass("return");
			$("#pkgcode").val("");
		}else{
			$(this).addClass("return");
			$("#pkgcode").val(this.id);
			$("#select_Package .icon-select[id !='" + this.id + "']").removeClass("return");
		}
	});
	$('.picturediv').hover(function(){			
		if($(this).children('p').children('img').attr("src",'../images/imgnone.png')){
		    $(this).children('span').hide();
		}else{
			$(this).children('span').show();
		}
	},function(){
		$(this).children('span').hide();
		});
	$('.left ul li').hover(function(){$(this).css('cursor','pointer');},function(){$(this).css('cursor','pointer');	});
	$('.blackbg').hover(function(){$(this).addClass('blackbg_style');},function(){$(this).addClass('blackbg').removeClass('blackbg_style');});
	$('.btnbg').hover(function(){$(this).addClass('btnbg_style');},function(){$(this).addClass('btnbg').removeClass('btnbg_style');});
	$('.addpackage').hover(function(){$(this).addClass('addpackage_style');},function(){$(this).addClass('addpackage').removeClass('addpackage_style');});
	$('.packagedelbtn').hover(function(){$(this).addClass('btnon_style');},function(){$(this).addClass('packagedelbtn').removeClass('btnon_style');});
	$('.btnyuyue').hover(function(){$(this).css('color','#dbdbda')},function(){$(this).css('color','#fff')});
	$('.btnnoyuyue').hover(function(){$(this).css('cursor','not-allowed')});
	$('.searchbtn').hover(function(){$(this).addClass('searchbtn_style');},function(){$(this).addClass('searchbtn').removeClass('searchbtn_style');});
	$('.fujin').hover(function(){$(this).addClass('fujin_style');},function(){$(this).addClass('fujin').removeClass('fujin_style');});
	$('.navbtn').hover(function(){$(this).addClass('navbtn_style');},function(){$(this).addClass('navbtn').removeClass('navbtn_style');});
	
	$('.close').click(function(){
		$(this).parent().parent('.stick-qrcode').hide();
	});
	//手机网站
	$('.phoneimg').hover(function(){
		$(this).children('#phoneimg').show();			
	},function(){
		$(this).children('#phoneimg').hide();
	});
	
})