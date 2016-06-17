@extends('app')
@section('content')

    @include('pages/nav')

        <div id="page-content-wrapper">
            @yield('user')
        </div>
@stop