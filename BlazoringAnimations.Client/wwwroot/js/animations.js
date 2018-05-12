const basicTimeline = anime.timeline({
    autoplay: false,
    complete: () => document.getElementById('btnShowHandicap').click()
});

Blazor.registerFunction('BlazoringAnimations.Client.JsInterop.CalculateAnimation', function () {
    basicTimeline.play();
});
Blazor.registerFunction('BlazoringAnimations.Client.JsInterop.ResetAnimation', function () {
    basicTimeline.reset();
});
Blazor.registerFunction('BlazoringAnimations.Client.JsInterop.InitAnimations', function () {
    console.log('Initializing animations');
    var pathEls = document.getElementsByClassName("check");
    for (var i = 0; i < pathEls.length; i++) {
        var pathEl = pathEls[i];
        var offset = anime.setDashoffset(pathEl);
        pathEl.setAttribute("stroke-dashoffset", offset);
    }
    basicTimeline
        .add({
            targets: ".text",
            duration: 1,
            opacity: "0"
        })
        .add({
            targets: ".button",
            duration: 1300,
            height: 20,
            width: 300,
            backgroundColor: "#2B2D2F",
            border: "0",
            borderRadius: 100
        })
        .add({
            targets: ".progress-bar",
            duration: 2000,
            width: 300,
            easing: "linear"
        })
        .add({
            targets: ".button",
            width: 0,
            duration: 1
        })
        .add({
            targets: ".progress-bar",
            width: 80,
            height: 80,
            delay: 500,
            duration: 750,
            borderRadius: 80,
            backgroundColor: '#3a0647'
        })
        .add({
            targets: pathEl,
            strokeDashoffset: [offset, 0],
            duration: 200,
            easing: "easeInOutSine"
        });

    var current = null;
    document.getElementById('par').addEventListener('focus', function (e) {
        addAnimation(0, 700, '300 1638');
    });
    document.getElementById('rating').addEventListener('focus', function (e) {
        addAnimation(-391, 700, '300 1638');
    });
    document.getElementById('slope').addEventListener('focus', function (e) {
        addAnimation(-780, 700, '300 1638');
    });
    document.getElementById('score').addEventListener('focus', function (e) {
        addAnimation(-1165, 700, '300 1638');
    });
    document.getElementById('add').addEventListener('focus', function (e) {
        addAnimation(-1422, 700, '240 1638');
    });
    function addAnimation(value, duration, dashArray) {
        if (current) current.pause();
        current = anime({
            targets: document.getElementById('snake'),
            strokeDashoffset: {
                value: value,
                duration: duration,
                easing: 'easeOutQuart'
            },
            strokeDasharray: {
                value: dashArray,
                duration: 700,
                easing: 'easeOutQuart'
            }
        });
    }
    //Horrible hack, but the only way I could get the path to find the defs. 
    document.getElementById('par').focus();
    var defs = document.getElementById('snake-svg').querySelector('defs');
    defs.innerHTML = "&nbsp;" + defs.innerHTML; 
});


