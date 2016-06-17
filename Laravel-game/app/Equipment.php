<?php namespace App;

use Illuminate\Database\Eloquent\Model;

class Equipment extends Model {

    protected $table = 'equipment';

    protected $fillable = ['user_id', 'type', 'name', 'attribute', 'image'];

    public function user()
    {
        return $this->belongsTo('App\User');
    }
}