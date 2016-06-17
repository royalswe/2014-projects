@extends('home')
@section('user')

    <br />
    <h3>Shop page</h3>

    @for ($i = 0; $i < 4; $i++)

    <li class="ShopItem">
        <?php $img = $shop[$i]['image'] ?> <img src="{{asset('img/equipment/'.$img)}}" class="img-responsive" width="2%" height="2%">
        <p>Type: {{ $type = $shop[$i]['type'] }}</p>
            <?php
            switch ($type) {
                case "Weapon":
                    $attribute = "Damage";
                    break;
                case "Armor":
                    $attribute = "Defense";
                    break;
                case "Charm":
                    $attribute = "Luck";
                    break;
            } ?>
            name: {{ $name = $shop[$i]['name'] }} / {{ $attribute }} : {{ $att = $shop[$i][$attribute] }} <?php $price = $shop[$i]['price'] ?>
         <a href="{{ URL::to("shop/$img/$type/$name/$att/$price") }}" class="btn btn-shop">Buy: {{ $price }} gold</a>
    </li>
    @endfor


    @if(Session::has('flash_message'))
        <div class="alert alert-warning"> {{ Session::get('flash_message') }} </div>
    @endif
@stop