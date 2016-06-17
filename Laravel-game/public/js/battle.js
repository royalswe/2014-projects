"use strict";

var Battle = {

    userStartHealth : userHealth,
    enemyStartHealth : oppHealth,

    init: function() {
        var nextTurn = document.getElementById("nextTurn");
        nextTurn.addEventListener("click", Battle.fight, false);
    },

    fight: function() {

            var luckyOpp = Math.random() * (oppLuck - 1) + 1;
            var luckyUser = Math.random() * (userLuck - 1) + 1;

            var battleInfo = document.getElementById("currentHit");

            if (luckyOpp > luckyUser) {
                userHealth = userHealth - oppDamage;

                Battle.newTurn('.hero-bar', oppDamage, Battle.userStartHealth, userHealth );

                battleInfo.innerHTML = 'you got hit';
            }
            else if (luckyOpp < luckyUser) {
                oppHealth = oppHealth - userDamage;

                Battle.newTurn('.enemy-bar', userDamage, Battle.enemyStartHealth, oppHealth );

                battleInfo.innerHTML = 'enemy got hit';
            }
            else{
                battleInfo.innerHTML = 'miss';
            }


       // document.getElementById("hero").innerHTML = userHealth;
       // document.getElementById("enemy").innerHTML = oppHealth;

        if(userHealth <= 0 || oppHealth <= 0) {

            nextTurn.remove(); // remove turn button

            if(userHealth <= 0){
                document.getElementById("userImg").src="img/ghost.gif";
                return document.getElementById("gameOver").innerHTML = 'you loose';

            }
            document.getElementById("enemyImg").src="img/ghost.gif";

            $.ajaxSetup(
                {
                    headers:
                    {
                        'X-CSRF-Token': $('input[name="_token"]').val()
                    }
                });

            if(raidLevel === undefined){
                return Battle.arenaGameOver();
            }

            return Battle.raidGameOver();

        }

    },

    newTurn: function(lifeBar, damage, startHealth, health) {

        var hit = Math.floor((damage / startHealth) * 100);

        var bar = $(lifeBar);
        $(function(){
            $(bar).each(function(){
                var bar_width = $(this).attr('aria-valuenow');
                var new_width = (+bar_width + +hit);

                $(this).width(new_width+'%');
                $(this).attr('aria-valuenow', new_width);
                $(lifeBar).children('.progress-text').text(health +" / "+ startHealth);
            });
        });
    },

    arenaGameOver: function(){

        if(oppHealth < 0){

            var gold = Battle.enemyStartHealth;
            var xp = 4;
            document.getElementById("gameOver").innerHTML = 'you won ' + xp + ' xp and ' + gold + ' gold';

            $.ajax( {
                type : 'POST',
                url  : 'reward',
                data : { gold : gold, xp : xp}
            } );
           // $.post('reward', function(data, status, xhr){ console.log(data); });

        }
    },
    raidGameOver: function(){

        if(oppHealth < 0){

            var gold = Battle.enemyStartHealth;
            var xp = 4;
            document.getElementById("gameOver").innerHTML = 'you won ' + xp + ' xp and ' + gold + ' gold.';

            $.ajax( {
                type : 'POST',
                url  : 'reward',
                data : { gold : gold, xp : xp, raidLevel : raidLevel}
            } );

        }
    }
};
window.onload = Battle.init;