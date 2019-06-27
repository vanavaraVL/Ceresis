/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./Scripts/home.component.load.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Scripts/home.component.load.js":
/*!****************************************!*\
  !*** ./Scripts/home.component.load.js ***!
  \****************************************/
/*! no static exports found */
/***/ (function(module, exports) {

﻿
var owl = $('.owl-carousel'),
    item,
    itemsBgArray = [], // to store items background-image
    itemBGImg;

owl.owlCarousel({
    items: 1,
    smartSpeed: 1000,
    autoplay: true,
    autoplayTimeout: 8000,
    autoplaySpeed: 1000,
    loop: true,
    nav: true,
    navText: false,
    onTranslated: function () {
        changeNavsThump();
    }
});

$('.active').addClass('anim');

var owlItem = $('.owl-item'),
    owlLen = owlItem.length;
/* --------------------------------
  * store items bg images into array
--------------------------------- */
$.each(owlItem, function (i, e) {
    itemBGImg = $(e).find('.owl-item-bg').attr('src');
    itemsBgArray.push(itemBGImg);
});
/* --------------------------------------------
  * nav control thump
  * nav control icon
--------------------------------------------- */
var owlNav = $('.owl-nav'),
    el;

$.each(owlNav.children(), function (i, e) {
    el = $(e);
    // append navs thump/icon with control pattern(owl-prev/owl-next)
    el.append('<div class="' + el.attr('class').match(/owl-\w{4}/) + '-thump">');
    el.append('<div class="' + el.attr('class').match(/owl-\w{4}/) + '-icon">');
});

/*-------------------------------------------
  Change control thump on each translate end
------------------------------------------- */
function changeNavsThump() {
    var activeItemIndex = parseInt($('.owl-item.active').index()),
        // if active item is first item then set last item bg-image in .owl-prev-thump
        // else set previous item bg-image
        prevItemIndex = activeItemIndex != 0 ? activeItemIndex - 1 : owlLen - 1,
        // if active item is last item then set first item bg-image in .owl-next-thump
        // else set next item bg-image
        nextItemIndex = activeItemIndex != owlLen - 1 ? activeItemIndex + 1 : 0;

    $('.owl-prev-thump').css({
        backgroundImage: 'url(' + itemsBgArray[prevItemIndex] + ')'
    });

    $('.owl-next-thump').css({
        backgroundImage: 'url(' + itemsBgArray[nextItemIndex] + ')'
    });
}
changeNavsThump();




//$(document).ready(() => {
//    'use strict';

//    $(function () {
//        $.scrollify({
//            section: ".sectionScroll",
//            sectionName: false,
//            interstitialSection: ".appFooter"
//        });
//    });

//    var owl = $('.owl-carousel'),
//        item,
//        itemsBgArray = [], // to store items background-image
//        itemBGImg;

//    owl.owlCarousel({
//        items: 1,
//        smartSpeed: 1000,
//        autoplay: true,
//        autoplayTimeout: 8000,
//        autoplaySpeed: 1000,
//        loop: true,
//        nav: true,
//        navText: false,
//        onTranslated: function () {
//            changeNavsThump();
//        }
//    });

//    $('.active').addClass('anim');

//    var owlItem = $('.owl-item'),
//        owlLen = owlItem.length;
//    /* --------------------------------
//      * store items bg images into array
//    --------------------------------- */
//    $.each(owlItem, function (i, e) {
//        itemBGImg = $(e).find('.owl-item-bg').attr('src');
//        itemsBgArray.push(itemBGImg);
//    });
//    /* --------------------------------------------
//      * nav control thump
//      * nav control icon
//    --------------------------------------------- */
//    var owlNav = $('.owl-nav'),
//        el;

//    $.each(owlNav.children(), function (i, e) {
//        el = $(e);
//        // append navs thump/icon with control pattern(owl-prev/owl-next)
//        el.append('<div class="' + el.attr('class').match(/owl-\w{4}/) + '-thump">');
//        el.append('<div class="' + el.attr('class').match(/owl-\w{4}/) + '-icon">');
//    });

//    /*-------------------------------------------
//      Change control thump on each translate end
//    ------------------------------------------- */
//    function changeNavsThump() {
//        var activeItemIndex = parseInt($('.owl-item.active').index()),
//            // if active item is first item then set last item bg-image in .owl-prev-thump
//            // else set previous item bg-image
//            prevItemIndex = activeItemIndex != 0 ? activeItemIndex - 1 : owlLen - 1,
//            // if active item is last item then set first item bg-image in .owl-next-thump
//            // else set next item bg-image
//            nextItemIndex = activeItemIndex != owlLen - 1 ? activeItemIndex + 1 : 0;

//        $('.owl-prev-thump').css({
//            backgroundImage: 'url(' + itemsBgArray[prevItemIndex] + ')'
//        });

//        $('.owl-next-thump').css({
//            backgroundImage: 'url(' + itemsBgArray[nextItemIndex] + ')'
//        });
//    }
//    changeNavsThump();
//});

/***/ })

/******/ });