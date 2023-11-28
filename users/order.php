<?php $page = 'post your order'; ?>
<?php
@session_start();
include("../connection.php");
include("../header.php"); 
if (isset($_POST['city'], $_POST['services']))
{
$city=mysqli_real_escape_string($con, $_POST['city']);
$services=mysqli_real_escape_string($con, $_POST['services']);
}
else{$city="";$services="";}
?>
<?php 
if(!isset($_SESSION['phone_no']))
{
?>
<body class="splash-index">
  <style type="text/css">
    body{
      overflow-x:hidden;
    }
  </style>
  <section class="teaser main-teaser bg-top" >
    <div class="min-space">
    </div>
    <div class="min-space">
    </div>
    <div class="min-space">
    </div>
    <h1 class="sub-title">Заказ
    </h1>
    <div class="min-space">
    </div>
    <div class="min-space">
    </div>
  </section>
  <section class="teaser">
    <?php
if(isset($_REQUEST['msg']))
{
$msg=$_REQUEST['msg'];
if($msg=="Inserted")
{
echo '<div class="succ-msg">Your Order has been updated sucessfully.We will send your account details for your registered Email </div>';
}
else if($msg=="Exist")
{
echo '<div class="err-msg">Phone No already exist</div>';		
}
else if($msg=="Invalid")
{
echo '<div class="err-msg">The postcode is invalid</div>';		
}
}
else
$msg="";
?>
    <form class="form-large" action="javascript:order_signin('add')" accept-charset="UTF-8" method="post">
      <div class="min-space">
      </div>
      <div class="col-lg-4 col-md-4 col-sm-4">
      </div>
      <div class="col-lg-4 col-md-4 col-sm-4">
        <h4>Город </h4>
        <select id="city_name" name="city_name" class="user-login__input user-login__input" required="required">
          <option value="">Нет в списке
          </option>
          <?php		
$res3=mysqli_query($con, "select * from sv_city order by city_id");
while($row3=mysqli_fetch_array($res3))
{
?>
          <option value="<?php echo $row3['city_id'];?>" 
                  <?php if($city==$row3['city_name']) echo "selected='selected'"; ?>>
          <?php echo $row3['city_name'];?>
          </option>
        <?php
}
?>
        </select>
		<div class="err" id="city_err"></div>
      </div>
    <div class="col-lg-4 col-md-4 col-sm-4">
    </div>
    <div class="row">
      <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6">
          <span class="title">Адрес</span>
          <input type="text" value="" class="user-login__input user-login__input" id="address" required="required">
		   <div class="err" id="address_err"></div>

        </div>
        <div class="col-lg-6 col-md-6 col-sm-6">
          <span class="title">Выбор даты
          </span>
          <input type="text" id="datepicker" name="datepicker" required="required" placeholder="Выбор даты" class="user-login__input user-login__input">
		  	 <div class="err" id="date_err"></div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-4">
          <span class="title">Услуга
          </span>
          <select required id="services" class="user-login__input user-login__input" onchange="javascript:sub_select(this.value);"> 
            <option value="">Нету в списке
            </option>
            <?php		
$res=mysqli_query($con, "select * from sv_services order by services_id");
while($row=mysqli_fetch_array($res))
{
$services_id=mysqli_real_escape_string($con, $row['services_id']);
$sname=mysqli_real_escape_string($con, $row['services_name']);
$query=mysqli_fetch_array(mysqli_query($con, "select * from sv_services_sub where services_name='$services_id'"));
$sub_sname=mysqli_real_escape_string($con, $query['services_sub_name']);
?>
            <option value="<?php echo $row['services_id'];?>" 
                    <?php if($services==$row['services_id']) echo "selected='selected'"; ?>>
            <?php echo $row['services_name'];?>
            </option>
          <?php
}
?>
          </select>
		  <div class="err" id="services_err"></div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-4">
        <span class="title">Дополнительная услуга
        </span>
        <select id="sub_services" class="user-login__input user-login__input" required onchange="javascript:price_select(this.value);"> 
          <option value="">Нету в списке
          </option>	
          <?php	
$res1=mysqli_query($con, "select * from sv_services_sub where services_name='$services'");
while($row1=mysqli_fetch_array($res1))
{			
?>
          <option value="<?php echo $row1['sid'];?>">
            <?php echo $row1['services_sub_name'];?>
          </option>
          <?php } ?>
        </select>
		 <div class="err" id="services_sub_err"></div>
      </div>
	  <div class="col-lg-4 col-md-4 col-sm-4">
<span class="title">Цена</span>
	<input type="text" value="" class="user-login__input user-login__input" id="price" name="price" readonly="readonly">
</div>

      <script src="../js/jquery-1.9.1.js">
      </script>
      <script src="../js/jquery-ui.js">
      </script>		
      <link rel="stylesheet" href="../css/jquery-ui.css">
      <script>
        $(function(){
          $( "#datepicker" ).datepicker({
            dateFormat: 'dd-mm-yy',constrainInput: false, changeMonth: false, changeYear: false,minDate: 0 }
                                       );
        }
         );
      </script>
      <div class="col-lg-6 col-md-6 col-sm-6">
        <span class="title">Выбор времени
        </span>
        <select id="time" class="user-login__input user-login__input" required>
          <option value="">None  </option>
          <option value="8:00 AM">08:00   </option>
          <option value="9:00 AM">09:00  </option>
          <option value="10:00 AM">10:00 </option>
          <option value="11:00 AM">11:00  </option>
          <option value="12:00 PM">12:00   </option>
          <option value="1:00 PM">13:00  </option>
          <option value="2:00 PM">14:00  </option>
          <option value="3:00 PM">15:00   </option>
          <option value="4:00 PM">16:00   </option>
          <option value="5:00 PM">17:00  </option>
        </select>
		 <div class="err" id="time_err"></div>
      </div>
      
	  
	  <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
<span class="title">Режим оплаты</span>
<select id="payment_mode" name="payment_mode" class="user-login__input user-login__input" required>
	<option value="">Нету в списке</option>
	<option value="cash">Наличные</option>
	<?php 
	$paypal=mysqli_fetch_array(mysqli_query($con, "select * from sv_admin_login"));
	$paypal_id=$paypal['paypal_id'];
	if($paypal_id!=="")
	{
	?>
	<option value="paypal">Paypal</option>
	<?php } ?>
</select>
 <div class="err" id="payment_mode_err"></div>
</div>
<div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
        <span class="title">Требование
        </span>
        <textarea id="req" class="user-login__input user-login__input req" required="required">
        </textarea>
      </div>
	  
    </div>
    </div>
	
	
  <div class="row">
    <div class="container">
      <h4>Личная информация
      </h4>
      <div class="col-lg-6 col-md-6 col-sm-6">
        <span class="title">Имя
        </span>
        <input type="text" id="name" class="user-login__input user-login__input" required="required">
		 <div class="err" id="name_err"></div>
      </div>
      <div class="col-lg-6 col-md-6 col-sm-6">
        <span class="title">Email
        </span>
        <input type="email" id="email_id" name="email_id" class="user-login__input user-login__input" required="required">
		 <div class="err" id="email_err"></div>
      </div>
      <div class="col-lg-6 col-md-6 col-sm-6">
        <span class="title">Телефон  </span>
        <input type="text" id="phone_no"  class="user-login__input user-login__input" required="required">
        <div class="err" style="color:#e00000" id="pno_err">
		<div class="err" id="pho_no_err"></div>
        </div> 
      </div>
      <div class="col-lg-6 col-md-6 col-sm-6">
        <span class="title">Пароль </span>
        <input type="password" id="password" class="user-login__input user-login__input" required="required">
		<div class="err" id="pwd_err"></div>
      </div>
    </div>
    <div class="container">
      <div class="col-lg-6 col-md-6 col-sm-6">
        <input type="submit" class="user-login__action" value="Забронируйте сейчас">
      </div>
    </div>
  </div>
  </form>
<div class="min-space">
</div>
</section>
</html>
<?php } else{ ?>
<?php 
@session_start();
$order_times = [];
if(isset($_SESSION['phone_no']))
{		
$phone_no=mysqli_real_escape_string($con, $_SESSION['phone_no']);
$query=mysqli_fetch_array(mysqli_query($con, "select * from sv_user_profile where phone_no='$phone_no'"));
$address=mysqli_real_escape_string($con, $query['address']);		
$name=mysqli_real_escape_string($con, $query['name']);
$pno=mysqli_real_escape_string($con, $query['phone_no']);

  $order_times_fetch=mysqli_query($con, "select order_time from sv_user_order where phone_no='$phone_no'");
  $i = 0;
  while($row=mysqli_fetch_array($order_times_fetch))
  {
    $order_times[$i] = $row[0];
    $i++;
  }
}	

?>
<body class="splash-index">
  <section class="teaser main-teaser bg-top" >
    <div class="min-space">
    </div>
    <div class="min-space">
    </div>
    <div class="min-space">
    </div>
    <h1 class="sub-title">Разместите свой заказ
    </h1>
    <div class="min-space">
    </div>
    <div class="min-space">
    </div>
  </section>
  <section class="teaser">
    <div class="min-space">
    </div>
    <form class="form-large" action="javascript:order_signup('add')" accept-charset="UTF-8" method="post">
      <div class="container">
        <?php
if(isset($_REQUEST['msg']))
{
$msg=$_REQUEST['msg'];
if($msg=="Inserted")
{
echo '<div class="succ-msg">Your Order has been updated sucessfully.</div>';
}
else if($msg=="Invalid")
{
echo '<div class="err-msg">Our service not available to this postcode</div>';		
}
}
else
$msg="";
?>
        <div class="col-lg-3 col-md-3 col-sm-3">
          <h3>
          </h3>
          <?php include("side_menu.php") ?>
        </div>
        <div class="col-lg-9 col-md-9 col-sm-9">
          <div class="row">
            <div class="">
              <h3>Название города
              </h3>
              <div class="col-md-3 col-sm-3 col-lg-3">
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6">
                <select id="city_name" name="city_name" class="user-login__input user-login__input" required="required">
                  <option value="">Нету в списке
                  </option>
                  <?php		
$res3=mysqli_query($con, "select * from sv_city order by city_id");
while($row3=mysqli_fetch_array($res3))
{
?>
                  <option value="<?php echo $row3['city_id'];?>" 
                          <?php if($city==$row3['city_name']) echo "selected='selected'"; ?>>
                  <?php echo $row3['city_name'];?>
                  </option>
                <?php
}
?>
                </select>
				 <div class="err" id="city_err"></div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3">
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
              <span class="title">Адрес
              </span>
              <input type="text" value="" id="address" class="user-login__input user-login__input" required="required">
			   <div class="err" id="address_err"></div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
              <span class="title">Выбор даты
              </span>
              <input type="text" id="datepicker" name="datepicker" required="required" placeholder="Select date" class="user-login__input user-login__input" >
			   <div class="err" id="date_err"></div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4">
              <span class="title">Услуга
              </span>
              <select id="services" class="user-login__input user-login__input" required="required" onchange="javascript:sub_select(this.value);">
                <option value="">Нету в списке
                </option>
                <?php		
$res=mysqli_query($con, "select * from sv_services order by services_id");
while($row=mysqli_fetch_array($res))
{
?>
                <option value="<?php echo $row['services_id'];?>" 
                        <?php if($services==$row['services_id']) echo "selected='selected'"; ?>>
                <?php echo $row['services_name'];?>
                </option>
              <?php
}
?>
              </select>
			   <div class="err" id="services_err"></div>
          </div>
          <div class="col-lg-4 col-md-4 col-sm-4 ">
            <span class="title">Дополнительные услуги
            </span>
            <select id="sub_services" class="user-login__input user-login__input" required="required" onchange="javascript:price_select(this.value);"> 
              <option value="">нету в списке
              </option>
              <?php	
$res1=mysqli_query($con, "select * from sv_services_sub where services_name='$services'");
while($row1=mysqli_fetch_array($res1))
{			
?>
              <option value="<?php echo $row1['sid'];?>">
                <?php echo $row1['services_sub_name'];?>
              </option>
              <?php } ?>
            </select>
			 <div class="err" id="services_sub_err"></div>
          </div>
		  
<div class="col-lg-4 col-md-4 col-sm-4">
<span class="title">Цена</span>
	<input type="text" value="" class="user-login__input user-login__input" id="price" name="price" readonly="readonly">
</div>
          <script src="../js/jquery-1.9.1.js">
          </script>
          <script src="../js/jquery-ui.js">
          </script>
          <link rel="stylesheet" href="../css/jquery-ui.css">
          <script>
            $(function(){
              $( "#datepicker" ).datepicker({
                dateFormat: 'dd-mm-yy',constrainInput: false, changeMonth: false, changeYear: false,minDate: 0 }
                                           );
            }
             );
          </script>
          <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
            <span class="title">Выбор времени
            </span>
            <select id="time" required="required" class="user-login__input user-login__input">
              <option value="">Нету в списке </option>
              <? 
              if(!in_array('8:00 AM', $order_times)){echo '<option value="8:00 AM">08:00   </option>';}
              if(!in_array('9:00 AM', $order_times)){echo '<option value="9:00 AM">09:00  </option>';}
              if(!in_array('10:00 AM', $order_times)){echo '<option value="10:00 AM">10:00 </option>';}
              if(!in_array('11:00 AM', $order_times)){echo '<option value="11:00 AM">11:00  </option>';}
              if(!in_array('12:00 PM', $order_times)){echo '<option value="12:00 PM">12:00   </option>';}
              if(!in_array('1:00 PM', $order_times)){echo '<option value="1:00 PM">13:00  </option>';}
              if(!in_array('2:00 PM', $order_times)){echo '<option value="2:00 PM">14:00  </option>';}
              if(!in_array('3:00 PM', $order_times)){echo '<option value="3:00 PM">15:00   </option>';}
              if(!in_array('4:00 PM', $order_times)){echo '<option value="4:00 PM">16:00   </option>';}
              if(!in_array('5:00 PM', $order_times)){echo '<option value="5:00 PM">17:00  </option>';}        
              ?>
            </select> 
			<div class="err" id="time_err"></div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
            <span class="title">Требование
            </span>
            <textarea id="req" class="user-login__input user-login__input" required="required" placeholder="Type your requirement here...">
            </textarea>
          </div>
		  <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
<span class="title">Режим оплаты</span>
<select id="payment_mode" name="payment_mode" class="user-login__input user-login__input" required>
	<option value="">Нету в списке</option>
	<option value="cash">Наличные</option>
	<?php 
	$paypal=mysqli_fetch_array(mysqli_query($con, "select * from sv_admin_login"));
	$paypal_id=$paypal['paypal_id'];
	if($paypal_id!=="")
	{
	?>
	<option value="paypal">Paypal</option>
	<?php } ?>
</select>
 <div class="err" id="payment_mode_err"></div>
</div>

        </div>
      </div>
	  
	 
	  
      <div class="row">
        <div class="">
          <div class="col-lg-12 col-md-12 col-sm-12 col-md-12 col-sm-12">
            <h3 style="text-align:center;">Личная информация
            </h3>
            <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
              <span class="title">Имя
              </span>
              <input type="text" id="name" required="required" class="user-login__input user-login__input" value="<?php echo $name; ?>">
			   <div class="err" id="name_err"></div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
              <span class="title">Телефон
              </span>
              <input type="text" id="order_pno" required="required" class="user-login__input user-login__input" value="<?php echo $pno; ?>">
              <div class="err" style="color:#e00000" id="pno_err">
			   <div class="err" id="pho_no_err"></div>
              </div> 
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-md-6 col-sm-6">
              <input type="submit" value="Разместить заказ" class="user-login__action" >
            </div>
          </div>
        </div>
      </div>
      <div class="min-space">
      </div>
      </div>
    </div>
  </form>
</section>
</html>
<?php } ?>
<?php include("../footer.php") ?>
