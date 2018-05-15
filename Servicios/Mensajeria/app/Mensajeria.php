<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Mensajeria extends Model
{
    protected $table = 'mensajeria';
    protected $guarded = ['id'];
    public $timestamps = false;

    public function modulo()
    {
        return $this->belongsTo('App\Modulos', 'modulo', 'id');
    }

    public function mensajero()
    {
        return $this->belongsTo('App\Mensajeros', 'mensajero', 'id');
    }

    public function tracking()
    {
        return $this->hasMany('App\TrackingMensajeria', 'mensajeria', 'id');
    }
}
