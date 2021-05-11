// JavaScript Document
$(function(){
	//各种文本框，下拉框，文本域获得焦点边框线绿色，失去焦点边框线灰色或无
	$('.txtinput_order,textarea,.txtinputs').focus(function(){$(this).css('border','1px solid #1eb699')});
	$('.txtinput_order,textarea,.txtinputs').blur(function(){$(this).css('border','1px solid #ccc')});
	
	$('.txtinput').focus(function(){$(this).css('border','1px solid #1eb699')});
	$('.txtinput').blur(function(){$(this).css('border','1px solid #cdcccc')});
	//搜索框点击 边框线绿色，刷新一次，线 无色
	$('.search').bind('click',function(){		
		$(this).css('border','1px solid #1eb699');
		});
		//申请套餐，点击选中 再次点击不选中
	$(".gou").bind('click',
	function(){
		if($(this).hasClass("return")){
		$(this).removeClass("return");
		}else{
		$(this).addClass("return");
		}
	});
	//箭头向下，点击向上，再次点击 向下
	$(".jt_down").bind('click',
	function(){					 
		if($(this).hasClass("returns")){
		$(this).removeClass("returns").next('.showwl').slideUp();
		}else{
		$(this).addClass("returns").next('.showwl').slideDown();;
		}
	});
	//选择套餐
	$('.classf').click(function(){
		if($(this).children('em').hasClass('dx')){
			$(this).children('em').removeClass("dx");
			}else{
				$(this).children('em').addClass("dx");
				}
		$('#showclass,#showfm').slideToggle();					   
	});
	//可选套餐显示隐藏，箭头上下切换
	$('#kexuan').click(function(){
		if($(this).children('b').hasClass('up')){
			$(this).children('b').removeClass("up");
			}else{
				$(this).children('b').addClass("up");
				}
		$('#kexuan_package').slideToggle();
	});
	//填写订单
	$(".orderjt").bind('click',
	function(){								  		 
		if($(this).hasClass("up")){
		$(this).removeClass("up")
		$(this).parent().next('.orderwr').slideUp();										
		}else{										  
		$(this).addClass("up");
		$(this).parent().next('.orderwr').slideDown();
		}
	});
	//订单页可选套餐显示隐藏 ，箭头上下切换
	$(".orderjt").bind('click',
	function(){
		if($(this).hasClass("ups")){
		$(this).removeClass("ups")
		$(this).parent().next('#showkx').slideUp();										
		}else{										  
		$(this).addClass("ups");
		$(this).parent().next('#showkx').slideDown();
		}
	});
	//套餐内容查看更多
	var summarys = $(".summarys").html();
		$(".summarys").delegate(".more", "click", function () {
			if ($(this).hasClass("cur")) {
				$(this).parent($(".summarys")).html(summarys);
			} else {
				$(this).parent($(".summarys")).html($(".summary").html() + '<a href="javascript:;" class="jiantou more cur"></a>');
			}
		});
		//常见问题 
		$('.faqdiv p').click(function(){
			if($(this).children('b').hasClass('up')){
				$(this).children('b').removeClass('up');
				}
			else{
				$(this).children('b').addClass('up');			
				}
				$(this).next('.showfaq').slideToggle();
});

			
		//售后服务
		$('#cproposals').click(function(){$('.c_proposals').slideToggle();});
		$('#apply').click(function(){$('.applyorder').slideToggle();});
})

