@extends('home')
@section('user')
    <br />
    <h3>Town Hall page</h3>


    <table class="table table-striped">
        <thead>
        <tr>
            <th>Username</th>
            <th>Damage</th>
            <th>Health</th>
            <th>Raid level</th>
        </tr>
    </thead>
    <tbody>
    @foreach($listOfUsers as $listOfUsers)
        <tr>
            <td>{{ $listOfUsers->user->username }}</td>
            <td>{{ $listOfUsers->damage }}</td>
            <td>{{ $listOfUsers->health }}</td>
            <td>{{ $listOfUsers->raid }}</td>
        </tr>
    @endforeach
    </tbody>
@stop
