import { Component, OnInit } from '@angular/core';
import * as $ from 'assets/js/jquery-3.4.1.min.js';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.doSmoothScrolling();
  }

  doSmoothScrolling(): void {
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
