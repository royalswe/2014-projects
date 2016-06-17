<?php namespace App\Http\Controllers;

use App\Stats;
use App\Http\Requests;
use App\Http\Controllers\Controller;

use App\User;
use Auth;
use Illuminate\Http\Request;

class StatsController extends Controller {

    public function __construct()
    {
        $this->middleware('auth');
    }
    /**
     * Get stats from user
     *
     * @return \Illuminate\View\View
     */
    public function stats()
    {
        $stats = Auth::user()->stats->first();
        $equipment = Auth::user()->equipment;

        $xp = Stats::where('user_id', \Auth::id())->pluck('xp');
        $nextLevel = -1;
        $level = 0;

        // calculate level up's
        while($nextLevel < $xp){
            $nextLevel += pow(($level+1),2)+30*pow(($level+1),2)+30*($level+1)-50;
            $level++;
        }
        //Show level in percent
        $percent = ($xp - $level) / ($nextLevel - $level) * 100 ;


        return view('pages.user', compact('stats', 'equipment', 'nextLevel', 'level', 'percent', 'xp'));
    }

    public function townhall()
    {
        $listOfUsers = Stats::all();
        return view('pages.townhall', compact('listOfUsers'));
    }

    public function statsIncrement($row)
    {
        $userId = Auth::id();
        $stats = new Stats();

        // Get value from stats table
        $inc = Stats::where('user_id', $userId)->pluck($row);
        //$inc = Stats::pluck($row);
        $gold = Stats::where('user_id', $userId)->pluck('gold');

        if ($row == 'damage' && $gold >= $inc-5) {
            $stats->where('user_id', $userId)->increment('damage', 1);
            $stats->where('user_id', $userId)->decrement('gold', $inc-5);
        }
        else if ($row == 'health' && $gold >= $inc-50) {
            $stats->where('user_id', $userId)->increment('health', 1);
            $stats->where('user_id', $userId)->decrement('gold', $inc-50);
        }
        else if ($row == 'luck' && $gold >= $inc+5) {
            $stats->where('user_id', $userId)->increment('luck', 1);
            $stats->where('user_id', $userId)->decrement('gold', $inc+5);
        }
        else{
            return redirect()->back()->with(\Session::flash('flash_message', 'Not enough gold'));
        }

        return redirect()->back();
    }

}
