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

  doSmoothScrolling() {
    var currentItem = 1;
    let finishAnimate = true;

    function autoScroll() {
      setInterval(function () { getNext(); }, 10000);
    }

    autoScroll();

    function scroll() {
      $('body').bind('mousewheel', function (e) {
        getNext();
      });
    };

    function getNext() {
      if (currentItem < 5 && finishAnimate) {
        finishAnimate = false;
        let slideBtn = $(`[data-btn='${Number(currentItem) + 1}']`);
        $(slideBtn).addClass('selected').siblings('button').removeClass('selected');
        $('.slideDiv').animate({
          top: -$('.slide-container').height() * $(slideBtn).index()
        }, 450, function () {
          finishAnimate = true;
        });
        currentItem++;
      }
    }

    scroll();

    function controls() {
      $(this).addClass('selected').siblings('button').removeClass('selected');
      currentItem = $(this).attr("data-btn");
      $('.slideDiv').animate({
        top: -$('.slide-container').height() * $(this).index()
      }, 450);
    }

    /***Event Listeners***/
    const runCode = () => {
      const button = document.querySelectorAll('.section-anchor');
      if (button) {
        for (let i = 0; i < button.length; i++) {
          button[i].addEventListener('click', controls, false);
        }
      }
    }
    runCode();

    $(".cd-scroll-down").click(function () {
      currentItem = $(this).data("slide");
      let slideNumber = currentItem + 1;
      let slideBtn = $(`[data-btn='${slideNumber}']`);
      slideBtn.addClass('selected').siblings('button').removeClass('selected');

      $('.slideDiv').animate({
        top: -$('.slide-container').height() * $(this).data("slide")
      }, 450);
    });
  }
}
