@extends('home')
@section('user')

    <br />
    <h3>Charakter page</h3>

    <div class="row">
        <div class="col-md-4">

            <div class="list-group list-group-user">
                <a href="#" class="list-group-item">
                    <span class="glyphicon glyphicon-user"> user: {{ $stats->user->username }}</span><span class="userGold">Gold: {{ $stats->gold }}</span>
                </a>

                <a href="user/health" class="list-group-item">
                    <span class="glyphicon glyphicon-heart"></span> Health: {{ $stats->health }} <span class="badge">{{ $stats->health-50 }} gold</span>
                </a>
                <a href="user/damage" class="list-group-item">
                    <span class="glyphicon glyphicon-tint"></span> Damage:  {{ $stats->damage }} <span class="badge">{{ $stats->damage-5 }} gold</span>
                </a>
                <a href="user/luck" class="list-group-item">
                    <span class="glyphicon glyphicon-star"></span> Luck: {{ $stats->luck }} <span class="badge">{{ $stats->luck+5 }} gold</span>
                </a>
                {{--<li>Health: {{ $stats->health }}<a href="{{ URL::to('user/health') }}" class="btn btn-info btn-xs">Buy: {{ $stats->health/5 }}</a></li>--}}


                <div class="progress">
                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="45"
                         aria-valuemin="0" aria-valuemax="100" style="width:{{$percent}}%">
                        {{ floor($percent). '% ' . '('. $xp . ' / ' . $nextLevel .')' }}
                    </div>
                    Level: {{ $level }}
                </div>

            </div>

        </div>
        <div class="col-md-4">
            <img src="{{asset('img/viking.svg')}}" class="img-responsive character-img" alt="viking">
        </div>

        <div class="col-md-4">
            <div class="equipment-stack">
                @foreach($equipment as $equipment)

                    <img src="{{asset('img/equipment/'.$equipment->image)}}" class="img-responsive equipment-img" alt="viking">
                    <div class="equipment-stats">
                        <span class="itemType">{{$equipment->type}}=</span>
                        {{$equipment->name}}:
                        {{$equipment->attribute}}
                    </div>
                @endforeach

            </div>
        </div>

    </div>

    @if(Session::has('flash_message'))
        <div class="alert alert-warning"> {{ Session::get('flash_message') }} </div>
    @endif

<script>
    $('div.alert').delay(2000).fadeOut(300)
</script>

@stop

