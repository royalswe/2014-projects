<?php namespace App\Http\Controllers;

use App\Equipment;
use App\Http\Requests;
use App\Http\Controllers\Controller;
use App\Shop;

use App\Stats;
use App\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use League\Flysystem\Exception;

class ShopController extends Controller {

    public function __construct()
    {
        $this->middleware('auth');
    }

    /**
     * Get Shop items from class
     */
    public function index()
    {
        $buyArr = New Shop();
        $shop = $buyArr->buy();

        return view('pages.shop', compact('shop'));
    }

    /**
     * Get Shop items from class
     */
    public function buy($img, $type, $name, $att, $price)
    {

        // Check if equipment already equipped
        $checkIfRowExist = Equipment::where('user_id', Auth::id())->where('image', $img)->where('type', $type)->where('name', $name)->where('attribute', $att);

        if($checkIfRowExist->exists())
        {
            return redirect()->back()->with(\Session::flash('flash_message', 'You already have that equipment'));
        }

        // Withdraw money from user
        $userGold =  Stats::where('user_id',Auth::id())->pluck('gold');

        if($userGold < $price)
        {
            return redirect()->back()->with(\Session::flash('flash_message', 'Not enough gold'));
        }

        try
        {
            // pay for item
            Stats::where('user_id',Auth::id())->decrement('gold', $price);

            // Add equipment in the table
            $user = Equipment::where('user_id', Auth::id())->where('type', $type);

            if($user->exists())
            {
                $user ->update(['image' => $img, 'name' => $name, 'attribute' => $att]);
            }
            else
            {
                Equipment::create([
                    'user_id' => Auth::id(),
                    'type' => $type,
                    'name' => $name,
                    'attribute' => $att,
                    'image' => $img
                ]);
            }
        }
        catch(\Exception $e)
        {
            throw new Exception('Equipment could not be bought');
        }

        return redirect()->back()->with(\Session::flash('flash_message', 'You bought '. $name));

    }

}
