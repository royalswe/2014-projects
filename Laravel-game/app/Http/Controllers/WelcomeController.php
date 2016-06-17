<?php namespace App\Http\Controllers;

use App\Equipment;
use App\Stats;
use App\User;
use Illuminate\Support\Facades\Auth;
use Request;

class WelcomeController extends Controller {

	/*
	|--------------------------------------------------------------------------
	| Test Controller
	|--------------------------------------------------------------------------
	|
	| Nothing to see here it is only for test purpose.
	|
	|
	|
	*/

	/**
	 * Create a new controller instance.
	 *
	 * @return void
	 */
//	public function __construct()
//	{
//		$this->middleware('guest');
//	}

	/**
	 * Show the application welcome screen to the user.
	 *
	 * @return Response
	 */
	public function index()
	{
		return view('welcome');
	}

    public function test()
    {
        //$user = Auth::user()->stats->with('User');
        $user = Auth::user()->stats->first();
        //$opponent = Stats::orderByRaw("RAND()")->whereNotIn('user_id', [Auth::id()])->with('User')->first();

        $opponent = Equipment::with('user')->first();

        //$newUser= User::orderBy("RAND()")->whereNotIn('user_id', [Auth::id()]);

        $newopponent = User::orderByRaw("RAND()")->whereNotIn('id', [Auth::id()])->pluck('id');
        $de = Stats::where('user_id', $newopponent)->first();
        $dr = Equipment::where('user_id', $newopponent)->get();
        $he = User::with('stats')->with('equipment')->first();

        return view('pages.test', compact('user', 'opponent', 'newopponent', 'de', 'dr', 'he'));

    }
    public function getTest()
    {
        return redirect()->back()->with('fight', 'fight');
      //  return redirect()->back()->with(\Session::flash('flash_message', 'Not enough gold'));
    }

}
