//
// Dynamsoft JavaScript Library for Basic Initiation of Dynamic Web TWAIN
// More info on DWT: http://www.dynamsoft.com/Products/WebTWAIN_Overview.aspx
//
// Copyright 2018, Dynamsoft Corporation 
// Author: Dynamsoft Team
// Version: 13.4.1
//
/// <reference path="dynamsoft.webtwain.initiate.js" />
var Dynamsoft = Dynamsoft || { WebTwainEnv: {} };

Dynamsoft.WebTwainEnv.AutoLoad = true;

///
Dynamsoft.WebTwainEnv.Containers = [{ContainerId:'dwtcontrolContainer', Width:270, Height:350}];

/// If you need to use multiple keys on the same server, you can combine keys and write like this 
/// Dynamsoft.WebTwainEnv.ProductKey = 'key1;key2;key3';
Dynamsoft.WebTwainEnv.ProductKey = 'A09DA3DED6A82428443EB898B1AD747608CFF64EE6CDC35F97750B67133273DA6A2FFDB353E0D82762F632AADFF3F0E86A2FFDB353E0D827A7BCA8C730B7192508CFF64EE6CDC35FDE99B453E1C3CBC040000000;t0068WQAAAFggjYa632Dz+Uy744l//ySnwK8pUxn+ya5+ohYpmfFk/Eyrs2K0+A1jvZe1C9RNes2EIKizcNvYGsB7rKLQgGs=';

///
Dynamsoft.WebTwainEnv.Trial = true;

///
Dynamsoft.WebTwainEnv.ActiveXInstallWithCAB = false;

///
Dynamsoft.WebTwainEnv.IfUpdateService = false;

///
// Dynamsoft.WebTwainEnv.ResourcesPath = 'Resources';

/// All callbacks are defined in the dynamsoft.webtwain.install.js file, you can customize them.
// Dynamsoft.WebTwainEnv.RegisterEvent('OnWebTwainReady', function(){
// 		// webtwain has been inited
// });

