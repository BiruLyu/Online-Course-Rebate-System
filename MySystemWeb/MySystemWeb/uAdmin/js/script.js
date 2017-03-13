(function() {
	//WebOS
	var WebOS = {
		init: function(options){
			var defaults = {
				navList: 'header',
				content: 'article',
				tween : 'Quad',
				easing:'easeOut',
				navClass:"section-nav",
				currentClass:"current",
				bgMark:".bg-mark",
				duration: 5,
				//imgUrl :'images/bg_{num}.jpg',
				bgImg:[],
				searchForm:'.search-form-mod',
				bgIndex:0
			};
			//location.replace('#');//scroll to top
			this.options = $.extend([],defaults,options);
			this.$bm = this.getBgMask();
			this.changeBg();

			this.tabScroll();
			this.searchInit();
			this.subappsInit();
		},
		
		subappsInit:function(){
			$('.subapps').parent('li').mouseenter(function(){
				var $this = $(this),
					$sa = $this.find('.subapps'),
					ww = $(window).width(),
					lw = $this.width(),
					ll = $this.offset().left + 120,
					saw = $sa.width();
				
				if(ww>lw+saw && ll + saw > ww){
					$sa.addClass('subapps-right');
				} else{
					$sa.removeClass('subapps-right');
				}
				
			})
		},
		
		getBgMask: function(){
			var html = '<div class="bg-wrap">';
				html += '<div class="bg-mask current"></div>';
				html += '<div class="bg-mask"></div>';
				html += '</div>';
			var $bm = $(html).appendTo('body').find('.bg-mask');
			return $bm;
		},
		//tab滚动切换
		tabScroll : function() {
			var options = this.options,
				$content = $(options.content),
				$navList = $(options.navList),
				$sections = $content.children(),
				sl=$sections.length,//section length
				$navs=initNavs(sl,options.navClass),//navigations
				that = this;
			
			$content.css('overflow','hidden');
			$sections.css('position','absolute');
			resetCurrentCls(0);
			initTurn();
			that.changeBg();
			$(window).bind('resize',function(){
				$content.height($content.find('.current').height());
			})
			
			function initNavs(len,className) {
				for(var i=0;i<len;i++) {
					$navList.append($('<span/>',{'class':className}));
				}
				$navList.delegate('.'+className, "mouseenter", function(){
					var $this = $(this);
					if($this.hasClass('current')) {
						return;
					}
					resetCurrentCls($navs.index(this));
					that.changeBg();
				})
				
				return $navList.children();
			}
			
			function initTurn(){
				var html = '<div class="section-turn-wrap">';
					html += '<div class="section-turn prev"></div>';
					html += '<div class="section-turn next"></div>';
					html += '</div>';
					
				var $turns = $(html).appendTo('body').find('.section-turn');
				$turns.click(function(){
					var $this = $(this),
						len = $navs.length,
						ci = $navs.index($navs.filter('.current')),
						ti = -1;
					if($this.hasClass('prev')){
						ti = (ci+len-1)%len;
					}
					else{
						ti = (ci+len+1)%len;
					}
					$navs.eq(ti).mouseenter();
				})
			}
	
			function resetCurrentCls(index) {
				$navs.removeClass('current');
				$sections.removeClass('current');
				$navs.eq(index).addClass('current');
				$content.height($sections.eq(index).addClass('current').height());
			}
			
		},
		
		changeBg :function(){
			//debugger;
			var options = this.options,
				$bm = this.$bm,
				ls = window.localStorage || {};
			function getRand(len) {
				
				return Math.floor(Math.random()*len);
			}
			function getBgNum(){
				var len = options.bgImg.length,
					randNum = getRand(len);
				
				if(ls.bgNum) {
					while(ls.bgNum==randNum) {
						//console.log(randNum);
						randNum = getRand(len);
					}
				}
				ls.bgNum = randNum;
				
				return ls.bgNum;
			}

			function getRandBg(){
				var bgNum = getBgNum();
				return options.bgImg[bgNum];
			}
			
			function creatImage(src,success,error){
				var $img = $('<img />');
				//img.onerror = error;
				$img.load(function(){
					success();
				});
				$img.attr('src',src);
			}	
			
			function setBgImg(url){
				
				$bm.filter(':not(.current)').css({'background-image':'url('+url+')'});
				$bm.toggleClass('current');
			}
			
			var src = getRandBg();
			creatImage(src,function(){
				setBgImg(src);
			})
			
		},
		searchInit:function(){
			var options = this.options,
				$form = $(options.searchForm);
				
				if($form.length>0){
					var $searchInput = $form.find('input[type=search]');
				}
				else{
					return;
				}
			
			$form.submit(function(e) {
				if(!$searchInput.val()) {
					return false;
				}
			});

			
			$form.find('input[type=submit]').click(function(){
				var $this = $(this);
				$form.attr('action',$this.attr('search-url'));
				$searchInput.attr('placeholder',$this.attr('placeholder'));
				$searchInput.attr('name',$this.attr('search-name'));
			})
		}
		
		
	}
	window.WebOS = WebOS;
	
})();