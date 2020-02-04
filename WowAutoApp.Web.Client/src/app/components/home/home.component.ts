import { Component, OnInit, HostListener } from '@angular/core';
import * as $ from 'assets/js/jquery-3.4.1.min.js';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(
    private _title: Title
  ) { }

  ngOnInit() {
    this._title.setTitle('Wowauto');
    this.doSmoothScrolling();
    this.scale(window.innerHeight, window.innerWidth);
  }

  scale(height, width){
    let wrappers = Array.from(document.querySelectorAll('.container.flex-centered'));
    const containerHeightConst = 750;
    let scaleConst = 1 - (containerHeightConst - height + 100) / containerHeightConst;
    wrappers.forEach(x=> {
      if(containerHeightConst + 100 >= height && width > 1288){
        x.setAttribute("style", `transform: scale(${scaleConst})`);
      }
      else{
        x.setAttribute("style", `transform: scale(1)`);
      }
    });
  }

  doSmoothScrolling(): void {

    function scale(height, width){
      let wrappers = Array.from(document.querySelectorAll('.container.flex-centered'));
      const containerHeightConst = 750;
      let scaleConst = 1 - (containerHeightConst - height + 100) / containerHeightConst;
      wrappers.forEach(x=> {
        if(containerHeightConst + 100 >= height && width > 1288){
          x.setAttribute("style", `transform: scale(${scaleConst})`);
        }
        else{
          x.setAttribute("style", `transform: scale(1)`);
        }
      });
    }

    let slideNumber = 1; // number of current slide

    $(".cd-scroll-down").click(function () {
      slideNumber++;
      animate();
    });

    function scrollDown() {
        slideNumber++;
        animate();
    };

    var autoScroll = setInterval(scrollDown, 10000);

    function scroll() {
      let isPauseFinished = true;
      $('body').bind('mousewheel', function (e) {
        if(isPauseFinished) {
          isPauseFinished = false;
          if(e.originalEvent.deltaY < 0){
            slideNumber--;
          } else {
            slideNumber++;
          };
          setTimeout(function(){
            isPauseFinished = true;
            clearInterval(autoScroll);
            autoScroll = setInterval(scrollDown, 10000);
          }, 500);
          animate();
        }
      });
    };

    scroll();

    function controls() {
      slideNumber = $(this).attr("data-slide");
      animate();
    };

    /***Event Listeners***/
    const runCode = () => {
      const button = document.querySelectorAll('.section-anchor');
      if (button) {
        for (let i = 0; i < button.length; i++) {
          button[i].addEventListener('click', controls, false);
        }
      }
    };

    runCode();

    function animate() {
      scale(window.innerHeight, window.innerWidth)
      validate();
      let slideBtn = $(`.section-anchor[data-slide=${slideNumber}]`);
      slideBtn.addClass('selected').siblings('button').removeClass('selected');
      $('.slideDiv').animate({
        top: -$('.slide-container').height() * $(slideBtn).index()
      }, 450);
    };

    function validate() {
        if(slideNumber > 5 || slideNumber < 1){
          slideNumber = 1;
        };
    };
  };

};
