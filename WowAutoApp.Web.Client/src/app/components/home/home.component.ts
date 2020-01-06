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
      function controls() {
        $(this).addClass('selected').siblings('button').removeClass('selected');
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

      $(".cd-scroll-down").click(function() {
        let slideNumber =  $(this).data("slide") + 1;
        let slideBtn =  $(`[data-btn='${slideNumber}']`);
        slideBtn.addClass('selected').siblings('button').removeClass('selected');
  
        $('.slideDiv').animate({
          top: -$('.slide-container').height() * $(this).data("slide")
        }, 450);
      });
  }

}
