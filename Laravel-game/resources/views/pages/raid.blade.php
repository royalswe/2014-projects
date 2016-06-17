@extends('home')
@section('user')
    <br />
    <h3>Raid page</h3>

    <div class="row">
        <div class="col-sm-4">
            <h3>{{ $user->user->username }}</h3>
            <div class="progress">
                <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="0" class="progress-bar progress-bar-danger hero-bar" role="progressbar" style="width: 0;">
                    <span class="progress-text"></span>
                </div>
            </div>
            <img id="userImg" src="{{asset('img/viking.svg')}}" class="img-responsive center-block" alt="viking" width="30%">

            <?php
            $plusLuck = $plusHealth = $plusDamage = 0;

            foreach($equipment as $equipment){

                if ($equipment->type == 'Charm'){
                    $plusLuck = $equipment->attribute;
                    //$charmImage = asset('img/equipment/'.$equipment->image);
                }
                if ($equipment->type == 'Armor'){
                    $plusHealth = $equipment->attribute;
                }
                if ($equipment->type == 'Weapon'){
                    $plusDamage = $equipment->attribute;
                }
            } ?>

            <ul class="list-group list-group-arena">
                <li class="list-group-item">Damage: <span class="badge">{{ $userDamage = $user->damage }} + {{ $plusDamage }}</span></li>
                <li class="list-group-item">Health: <span class="badge">{{ $userHealth = $user->health }} + {{ $plusHealth }}</span></li>
                <li class="list-group-item">Luck: <span class="badge">{{ $userLuck = $user->luck }} + {{ $plusLuck }}</span></li>
            </ul>

            {{--$noImg = asset('img/equipment/kidsSword.png'); --}}
            {{--<img src="{{$charmImage or $noImg}}" class="img-responsive" alt="viking">--}}


            <?php
            $userHealth = $userHealth + $plusHealth;
            $userDamage = $userDamage + $plusDamage;
            $userLuck = $userLuck + $plusLuck;

            // Get opponent id
            $opponent = $user->raid
            ?>

        </div>

        <div class="col-sm-4">
            <div class="center-class">
                <h3>Battle info</h3>
                <input id="nextTurn" type="button" class="btn btn-shop" value="Fight">
                <p id="currentHit"></p>
                <p id="gameOver"></p>
            </div>
        </div>

        <div class="col-sm-4">
           @if($opponent < 6)  <!-- Check if there is any opponents left in the array -->
                <h3>{{ $enemyName = $enemy[$opponent]['name'] }}</h3>
                <div class="progress">
                    <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="0" class="progress-bar progress-bar-danger enemy-bar" role="progressbar" style="width: 0;">
                        <span class="progress-text"></span>
                    </div>
                </div>
                <img id="enemyImg" src="{{asset('img/enemies/'.$enemy[$opponent]['image'])}}" class="img-responsive center-block" alt="enemy" width="30%">
                <br />
                <ul class="list-group list-group-arena">
                    <li class="list-group-item">Damage: <span class="badge">{{ $oppDamage = $enemy[$opponent]['damage'] }}</span></li>
                    <li class="list-group-item">Health: <span class="badge">{{ $oppHealth = $enemy[$opponent]['health'] }}</span></li>
                    <li class="list-group-item">Luck: <span class="badge">{{ $oppLuck = $enemy[$opponent]['luck'] }}</span></li>
                </ul>


                <script>
                    // assign stats to js variable
                    var userDamage = '<?php echo $userDamage ;?>';
                    var userHealth = '<?php echo $userHealth ;?>';
                    var userLuck = '<?php echo $userLuck ;?>';
                    var oppDamage = '<?php echo $oppDamage ;?>';
                    var oppHealth = '<?php echo $oppHealth ;?>';
                    var oppLuck = '<?php echo $oppLuck ;?>';
                    var raidLevel = '<?php echo $opponent ;?>';
                </script>

            @else
                You have completed all raid quests
            @endif
        </div>
    </div>
    <input type="hidden" name="_token" value="{{csrf_token()}}">
    <script src="js/battle.js"></script>

@stop