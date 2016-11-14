function vq3 = hint(x,v)
xq = length(x)+1;
vq3 = interp1(x,v,xq,'pchip','extrap');
