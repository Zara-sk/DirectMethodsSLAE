import matplotlib.pyplot as plt

fig = plt.figure()

ax = fig.add_subplot(111)

x = [100 + x*100 for x in range(5)]

gauss = [2, 8, 25,  50,  100]
lu = [2,  15,  33,  80,  149]
qr = [6,  26,  90,  232,  451]

ax.plot(x, gauss, label='Гаусс')
ax.plot(x, lu, label='LU')
ax.plot(x, qr, label='QR')
ax.grid(True)
ax.legend()

plt.show()