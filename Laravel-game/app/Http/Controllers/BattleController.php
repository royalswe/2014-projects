<?php namespace App\Http\Controllers;

use App\Equipment;
use App\Http\Requests;
use App\Http\Controllers\Controller;

use App\Stats;
use App\User;
use App\Enemies;
use League\Flysystem\Exception;
use Request;
use Illuminate\Support\Facades\Auth;

class BattleController extends Controller {

    public function __construct()
    {
        $this->middleware('auth');
    }

    /**
     * Get data from user and opponent
     */
    public function arena()
    {
        $user = Auth::user()->stats->first();
        $equipment = Auth::user()->equipment;
        //$opponent = Stats::orderByRaw("RAND()")->whereNotIn('user_id', [Auth::id()])->with('User')->first();

        $opponent = User::orderByRaw("RAND()")->whereNotIn('id', [Auth::id()])->pluck('id');
        $opponentStats = Stats::where('user_id', $opponent)->first();
        $opponentEquipment = Equipment::where('user_id', $opponent)->get();

        return view('pages.arena', compact('user', 'equipment', 'opponentStats', 'opponentEquipment'));
    }

    /**
     * Get data from user and opponent
     */
    public function raid()
    {
        $user = Auth::user()->stats->first();
        $equipment = Auth::user()->equipment;

        $enemyArr = New Enemies();
        $enemy = $enemyArr->getEnemy();

        return view('pages.raid', compact('user', 'enemy', 'equipment'));
    }

    /**
     * Get reward from a battle
     */
    public function reward()
    {
        try
        {
            $gold = Request::get( 'gold' );
            $xp = Request::get( 'xp' );

            $stats = new Stats();
            $stats->where('user_id', Auth::id())->increment('gold', $gold);
            $stats->where('user_id', Auth::id())->increment('xp', $xp);
            if(Request::get( 'raidLevel' )){
                $stats->where('user_id', Auth::id())->increment('raid');
            }

        }
        catch(\Exception $e)
        {
            throw new Exception('Reward was not updated');
        }

    }

}
